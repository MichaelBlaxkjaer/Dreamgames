namespace DreamGames.Database.Games
{
    public class Tag
    {
        public int Id { get; set; }
        //Full tag name
        public string TagName { get; set; }
        //The minimized name of the tag
        public string Slug { get; set; }
        //The internal ID the RawG api uses
        public int RawGTagId { get; set; }
    }
}