using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DreamGames.Database.Scenarios
{
    public class Scenario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Numbering { get; set; }
        public string Title { get; set; }
        [NotMapped]
        public List<Question> Question { get; set; }

    }
}
