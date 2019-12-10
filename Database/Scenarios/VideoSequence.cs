using System.Collections.Generic;
using DreamGames.Database.Scenarios;

namespace dreamgames.Database.Scenarios
{
    public class VideoSequence
    {
        public int Id { get; set; }
        public ICollection<Video> Videos { get; set; }
    }
}
