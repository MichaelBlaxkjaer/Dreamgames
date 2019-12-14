using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using dreamgames.Classes;
using DreamGames.Database.Context;
using dreamgames.Database.Games;
using DreamGames.Database.Games;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace dreamgames.Controllers
{
    public class ApiTestController : Controller
    {
        private readonly ContentContext _context;

        private ApiFetcher api;
        // GET: ApiTest
        public ActionResult Index()
        {
            api = new ApiFetcher(_context);
            //Dictionary<Tag, int> test = new Dictionary<Tag, int>();
            //test.Add(new Tag()
            //{
            //    RawGTagId = 36,
            //    Slug = "open-world",
            //    TagName = "Open World"
            //}, 4);
            //test.Add(new Tag()
            //{
            //    RawGTagId = 7,
            //    Slug = "multiplayer",
            //    TagName = "Multiplayer"
            //}, 1);
            //test.Add(new Tag()
            //{
            //    RawGTagId = 24,
            //    Slug = "rpg",
            //    TagName = "RPG"
            //}, 3);
            //test.Add(new Tag()
            //{
            //    RawGTagId = 32,
            //    Slug = "sci-fi",
            //    TagName = "Sci-Fi"
            //}, 1);
            //test.OrderBy(e => e.Value);
            //Game rawr = api.GetGameFromApi(test);


            return View();
        }
        public ApiTestController(ContentContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Here we have a function that gets us the needed games via a parameter
        /// we send along, and since its an async task, it wont actually move on
        /// until we have some sort of response, meaning the code wouldnt end up
        /// lacking the needed data down the line.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<ActionResult<string>> GetApiResponse(string param)
        {
            string url = "https://api.rawg.io/api/games?" + param;
            using (HttpClient client = new HttpClient())
            {
                return await client.GetStringAsync(url);
            }
        }
        /// <summary>
        /// This is an admin tool used to test the api.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetGames(IFormCollection collection)
        {
            string tags = "";
            foreach (var item in collection["tags"])
            { 
                tags +=  item + ",";
            }
            string response = GetApiResponse("tags="+tags).Result.Value;
            ViewData["test"] = response;
            return View("Index");
        }
        // GET: ApiTest/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ApiTest/Create
        public ActionResult Create()
        {
            return View();
        }
        /// <summary>
        /// Here we sync the API, when the "Sync" button is pressed, we run through the API
        /// provided by RawG and save the contents to our own database, this is done
        /// due to the api RawG provides is severely lacking on documentation as well
        /// as lacking many features needed to properly use it. So, we decided to use the
        /// data and make our own tools to use the data.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SyncApi()
        {
            try
            {
                //Here we get all the tags we have in the database into a list
                var tags = _context.Tags.ToList();
                //This for loop runs through 10 times, each time increasing the page number
                //we give the API to get more games since each call only returns 40 games at most
                for (int i = 1; i < 10; i++)
                {
                    //Here we run through the tags, the tag is then put into the api url, allowing us
                    //to make an api call for each tag, thus populating our database with games from
                    //all the tags we've decided on.
                    foreach (var tag in tags)
                    {
                        //Here we put together the api call and sends it along to the function that actually calls on the api
                        string response = GetApiResponse("tags=" + tag.RawGTagId + "&page_size=40&page="+i).Result.Value;
                        //We get a json object back, so here we make sure code knows this is what we want, allowing us to make a list out of the objects
                        var jsonObjects = JObject.Parse(response).SelectToken("results").Values<object>().ToList();
                        //Here we sleep the thread, making sure we wont get an automatic IP ban for overloading the api
                        Thread.Sleep(500);
                        //Here we go through all the objects.
                        foreach (var item in jsonObjects)
                        {
                            //The code couldnt seen to understand what each item were in the list, so here we make sure to parse it properly.
                            var jobj = JObject.Parse(item.ToString());
                            //Here we create our game object, using the keys from the json object to tell our code where to get each variable.
                            Game game = new Game()
                            {
                                GameId = jobj["id"].Value<int>(),
                                Title = jobj["name"].Value<string>(),
                                Slug = jobj["slug"].Value<string>(),
                                BackgroundImage = jobj["background_image"].Value<string>(),
                                AvgRating = jobj["rating"].Value<float>(),
                                Trailer = "trailer"
                            };
                            //Here we likewise do what we did above, making a new GameTagJunction object so we can save it in the database
                            GameTagJunction gameTagJunction = new GameTagJunction()
                            {
                                GameId = jobj["id"].Value<int>(),
                                TagId = tag.RawGTagId
                            };
                            //Here we make sure the game isnt already in the database, since the api
                            //would return the same game over and over if more than one our tags
                            //were present in the api. If its not already in our database, we go ahead and add it
                            if (!_context.Games.Any(e => e.GameId == game.GameId))
                            {
                                _context.Games.Add(game);
                                
                            }
                            //Here we do likewise, if the game is already already in the database,
                            //then check if the tag is also there. If both are already there, dont add
                            //it again. However, if the game is there, but the tag is not, then add it
                            if (!_context.GameTagJunction.Any(e =>
                                e.GameId == game.GameId && e.TagId == gameTagJunction.TagId))
                            {
                                _context.GameTagJunction.Add(gameTagJunction);
                            }
                            //Finally, we save the entire thing
                            _context.SaveChanges();
                            
                        }
                    }

                    
                }
                return RedirectToAction(nameof(Index));
            }
            catch(InvalidCastException e)
            {
                return View(nameof(Index));
            }
        }

        // GET: ApiTest/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ApiTest/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ApiTest/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ApiTest/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}