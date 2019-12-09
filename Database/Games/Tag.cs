namespace DreamGames.Database.Games
{
    public class Tag
    {
        public int Id { get; set; }
        public string TagName { get; set; }
        public string Slug { get; set; }
        public int RawGTagId { get; set; }
    }
}