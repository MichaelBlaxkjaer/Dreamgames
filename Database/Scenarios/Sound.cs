using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DreamGames.Database.Scenarios
{
    public class Sound
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        //The ID of the video the sound belongs to
        public int VideoId { get; set; }
        //The path to the sound
        public string UrlPath { get; set; }
        //In what order the sound should be played
        public int Order { get; set; }
    }
}