namespace Entities
{
    public class UserGameCollection : BaseEntity
    {

        public int UserId { get; set; }
        public int GameId { get; set; }
        public User User { get; set; }
    }
}
