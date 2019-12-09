using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Media;
using DreamGames.Database.Scenarios;

namespace DreamGames.Database.Scenarios
{
    public class Video
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public int Order { get; set; }
        public string UrlPath { get; set; }
        //ambiencePath has not been added, instead theres a table with sounds 
        //that has a "videoId", hvis is used to find what sounds fits the clip
        //I've made it like this incase we wanted multiple sounds for one clip
        [NotMapped]
        public List<Sound> Sound { get; set; }
    }
}