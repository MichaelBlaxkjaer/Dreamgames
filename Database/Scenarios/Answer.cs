using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DreamGames.Database.Scenarios
{
    public class Answer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Text { get; set; }
        public string ImagePath { get; set; }
        public int OutroVideo { get; set; }
        public int QuestionId { get; set; }
        public int AnswerOrder { get; set; }
        public int FollowUpQuestionId { get; set; }
        [NotMapped] 
        public List<TagPoint> TagPoints { get; set; }

    }
}