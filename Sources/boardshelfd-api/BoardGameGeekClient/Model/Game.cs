namespace BoardGameGeekClient.Model
{
    public class Game
    {
        public int Rank { get; set; }
        public int GameId { get; set; }
        public string Name { get; set; }
        public string Thumbnail { get; set; }
        public int YearPublished { get; set; }
    }
}