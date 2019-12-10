using System.Collections.Generic;
using dreamgames.Database.Scenarios;

namespace DreamGames.Database.Scenarios
{
    public class Answer
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string ImagePath { get; set; }
        public int AnswerOrder { get; set; }

        public int? OutroVideoId { get; set; }
        public VideoSequence OutroVideo { get; set; }

        public int QuestionId { get; set; }

        public int? FollowUpQuestionId { get; set; }
        public Question FollowUpQuestion { get; set; }

        public List<TagPoint> TagPoints { get; set; }
    }
}