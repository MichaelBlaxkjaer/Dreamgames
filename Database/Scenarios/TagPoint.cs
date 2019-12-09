using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using DreamGames.Database.Games;

namespace DreamGames.Database.Scenarios
{
    public class TagPoint
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int TagId { get; set; }
        public int AnswerId { get; set; }
        public int Point { get; set; }
    }
}
