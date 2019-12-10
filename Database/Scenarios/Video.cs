namespace DreamGames.Database.Scenarios
{
    public class Video
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public string Path { get; set; }
        public string AmbiencePath { get; set; }
        
        public int? VideoSequenceId { get; set; }
    }
}