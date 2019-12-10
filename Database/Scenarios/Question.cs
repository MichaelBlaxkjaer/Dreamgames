using System.Collections.Generic;
using dreamgames.Database.Scenarios;

namespace DreamGames.Database.Scenarios
{
    public class Question
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string MotivePath { get; set; }
        public int Ordering { get; set; }

        public int? IntroVideoId { get; set; }
        public VideoSequence IntroVideo { get; set; }

        public ICollection<Answer> Answers { get; set; }
    }

}