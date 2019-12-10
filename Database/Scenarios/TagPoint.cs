namespace DreamGames.Database.Scenarios
{
    public class TagPoint
    {
        public int Id { get; set; }
        //TagId mirrors an ID given to a tag in the Tag table
        public int TagId { get; set; }
        //What answer this belongs to
        public int AnswerId { get; set; }
        //How many points to add to the chosen tag
        public int Point { get; set; }
    }
}
