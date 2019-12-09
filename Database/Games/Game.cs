using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DreamGamesAPI.Database.Games
{
    public class Game
    {
        public int Id { get; set; }
        public float AvgRating { get; set; }
        public GameStore GameStores { get; set; }
        public string Title { get; set; }
        public Platform Platforms { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Screenshot Screenshots { get; set; }
        public Tag Tags { get; set; }
    }
}
