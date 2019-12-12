using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using dreamgames.Classes;
using DreamGames.Database.Context;
using dreamgames.Database.Games;
using DreamGames.Database.Games;
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
        public async Task<ActionResult<string>> GetApiResponse(string param)
        {
            string url = "https://api.rawg.io/api/games?" + param;
            using (HttpClient client = new HttpClient())
            {
                return await client.GetStringAsync(url);
            }
        }
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

        // POST: ApiTest/Create
        [HttpPost]
        public ActionResult SyncApi()
        {
            try
            {
                var tags = _context.Tags.ToList();
              
                foreach (var tag in tags)
                {
                    string response = GetApiResponse("tags=" + tag.RawGTagId + "&page_size=55").Result.Value;
                    var jsonObjects = JObject.Parse(response).SelectToken("results").Values<object>().ToList();

                    foreach (var item in jsonObjects)
                    {
                        var jobj = JObject.Parse(item.ToString());
                        Game game = new Game()
                        {
                            GameId = jobj["id"].Value<int>(),
                            Title = jobj["name"].Value<string>(),
                            Slug = jobj["slug"].Value<string>(),
                            BackgroundImage = jobj["background_image"].Value<string>(),
                            AvgRating = jobj["rating"].Value<float>(),
                            Trailer = jobj["clip"]["clip"].Value<string>()
                        };
                        GameTagJunction gameTagJunction = new GameTagJunction()
                        {
                            GameId = jobj["id"].Value<int>(),
                            TagId = tag.RawGTagId
                        };
                        if (!_context.Games.Any(e => e.GameId == game.GameId))
                        {
                            _context.Games.Add(game);
                            
                        }

                        if (!_context.GameTagJunction.Any(e =>
                            e.GameId == game.GameId && e.TagId == gameTagJunction.TagId))
                        {
                            _context.GameTagJunction.Add(gameTagJunction);
                        }
                        
                        _context.SaveChanges();
                    }

                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
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