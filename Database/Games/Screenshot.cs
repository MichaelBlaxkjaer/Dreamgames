using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DreamGames.Database.Games
{
    public class Screenshot
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int GameId { get; set; }
        public string Title { get; set; }
        public string ScreenshotUrl { get; set; }
    }
}