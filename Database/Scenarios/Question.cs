using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DreamGames.Database.Scenarios
{
    public class Question
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ScenarioId { get; set; }
        public int IntroVideoId { get; set; }
        public string Description { get; set; }
        public string MotivePath { get; set; }
        public int Ordering { get; set; }
        [NotMapped]
        public List<Answer> Answers { get; set; }
        [NotMapped]
        public List<Video> Video { get; set; }

    }

}