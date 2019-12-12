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
        

        public Game GetGameFromApi(Dictionary<Tag, int> TopTags)
        {
            Dictionary<int, List<int>> query = FilterGames(TopTags);

            return _context.Games.Where(e => e.GameId == query.Keys.First()).Single();

        }

        public Dictionary<int, List<int>> FilterGames(Dictionary<Tag, int> TopTags)
        {
            Tag[] tags = TopTags.Keys.ToArray();
            List<GameTagJunction> gameTagJunctions = _context.GameTagJunction.ToList();
            Dictionary<int, List<int>> dictionaryList = gameTagJunctions.GroupBy(e => e.GameId)
                .ToDictionary(t => t.Key, t => t.Select(e => e.TagId).ToList());
            Dictionary<int, List<int>> gamesDictionary = new Dictionary<int, List<int>>();
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
