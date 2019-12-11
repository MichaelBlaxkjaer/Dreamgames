using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DreamGames.Database.Games
{
    public class Game
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int GameId { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string BackgroundImage { get; set; }
        public float AvgRating { get; set; }
        public string Trailer { get; set; }
    }
}
