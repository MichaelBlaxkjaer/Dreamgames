using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DreamGames.Database.Scenarios
{
    public class Sound
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int VideoId { get; set; }
        public string UrlPath { get; set; }
        public int Order { get; set; }
    }
}