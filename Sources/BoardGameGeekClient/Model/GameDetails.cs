namespace BoardGameGeekClient.Model
{
    public class GameDetails
    {
        public int GameId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Thumbnail { get; set; }

        public int MinPlayers { get; set; }
        public int MaxPlayers { get; set; }

        public int YearPublished { get; set; }

        public double BGGRating { get; set; }
        public double AverageRating { get; set; }
        public int Rank { get; set; }

        public List<string> Designers { get; set; }
        public List<string> Publishers { get; set; }
        public List<string> Artists { get; set; }
    }
}
