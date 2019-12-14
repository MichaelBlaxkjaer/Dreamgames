using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DreamGames.Database.Context;
using dreamgames.Database.Games;
using DreamGames.Database.Games;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace dreamgames.Classes
{
    public class ApiFetcher
    {
        readonly private ContentContext _context;

        public ApiFetcher(ContentContext context)
        {
            _context = context;
        }
        
        /// <summary>
        /// Here, we get a hold of the tags, send them along to another function
        /// that was supposed to (But due to time contraints) sort the tags
        /// by the amount of points they had gotten in the test, which then
        /// allowed us to remove the tag with the least points in case there
        /// were no games that contained all tags, thus removing tags one by
        /// one until a game was found.
        /// </summary>
        /// <param name="TopTags"></param>
        /// <returns></returns>
        public Game GetGameFromApi(Dictionary<Tag, int> TopTags)
        {
            Dictionary<int, List<int>> query = FilterGames(TopTags);
            //Here we return the first game we find, if more time had been allowed
            //the game returned would have been picked more delicately.
            return _context.Games.Where(e => e.GameId == query.Keys.First()).Single();

        }
        /// <summary>
        /// This is where the tags were supposed to be ranked and then the tag
        /// with the lowest points would be removed if there were no games with
        /// all the tags.
        /// </summary>
        /// <param name="TopTags"></param>
        /// <returns></returns>
        public Dictionary<int, List<int>> FilterGames(Dictionary<Tag, int> TopTags)
        {
            //Here we put the tags into an array, as mentioned above, we didnt have the time
            //To make use of the score, so we simply grab the tags.
            Tag[] tags = TopTags.Keys.ToArray();
            //Here we get a hold of our database table called GameTagJunction and return them
            //the junction table is a way to bridge our other tables with tags and games
            //Thus, each tag a game has is saved in the junction table, instead of having
            //Multiple tags
            List<GameTagJunction> gameTagJunctions = _context.GameTagJunction.ToList();
            //Here we put all the junctions into a dictionary list where we use the gameID
            //as the key, and the tags the game has are the values connected to the id.
            Dictionary<int, List<int>> dictionaryList = gameTagJunctions.GroupBy(e => e.GameId)
                .ToDictionary(t => t.Key, t => t.Select(e => e.TagId).ToList());
            //Here we instantiate our games dictionary getting it ready to get the final
            //games that result from the filtering
            Dictionary<int, List<int>> gamesDictionary = new Dictionary<int, List<int>>();
            //Here we make a very "Jump over where the fence is the lowest" filtering process
            //Due to lack of time and this only being a prototype, this was simply made into a
            //if sentence, this is to make sure the code wouldnt shit itself if there were more
            //or less than the tags agreed upon.
            if (tags.Length == 5)
            {
                gamesDictionary = dictionaryList.Where(e =>
                    e.Value.Contains(tags[0].RawGTagId) &&
                    e.Value.Contains(tags[1].RawGTagId) &&
                    e.Value.Contains(tags[2].RawGTagId) &&
                    e.Value.Contains(tags[3].RawGTagId) &&
                    e.Value.Contains(tags[4].RawGTagId)
                ).ToDictionary(e => e.Key, e => e.Value);
            }
            else if (tags.Length == 4)
            {
                gamesDictionary = dictionaryList.Where(e =>
                    e.Value.Contains(tags[0].RawGTagId) &&
                    e.Value.Contains(tags[1].RawGTagId) &&
                    e.Value.Contains(tags[2].RawGTagId) &&
                    e.Value.Contains(tags[3].RawGTagId)
                ).ToDictionary(e => e.Key, e => e.Value);
            }
            else if (tags.Length == 3)
            {
                gamesDictionary = dictionaryList.Where(e =>
                    e.Value.Contains(tags[0].RawGTagId) &&
                    e.Value.Contains(tags[1].RawGTagId) &&
                    e.Value.Contains(tags[2].RawGTagId)
                ).ToDictionary(e => e.Key, e => e.Value);
            }
            else if (tags.Length == 2)
            {
                gamesDictionary = dictionaryList.Where(e =>
                    e.Value.Contains(tags[0].RawGTagId) &&
                    e.Value.Contains(tags[1].RawGTagId)
                ).ToDictionary(e => e.Key, e => e.Value);
            }
            else if (tags.Length == 1)
            {
                gamesDictionary = dictionaryList.Where(e =>
                    e.Value.Contains(tags[0].RawGTagId)
                ).ToDictionary(e => e.Key, e => e.Value);
            }
            return gamesDictionary;
        }
    }
}
