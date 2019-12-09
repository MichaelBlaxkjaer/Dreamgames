using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Media;

namespace DreamGamesAPI.Database.Scenarios
{
    public class Video
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public int Order { get; set; }
        public string UrlPath { get; set; }
        [NotMapped]
        public List<Sound> Sound { get; set; }
    }
}