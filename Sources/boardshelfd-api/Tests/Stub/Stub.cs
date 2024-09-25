using Dtos;

namespace Tests.Stub
{
    public class Stub
    {
        private static readonly string[] Users =
        {
            "user0", "User1", "User2", "User3", "User4"
        };
        
        public static IEnumerable<UserDto> GetUsers()
        {
            return Enumerable.Range(0, Users.Length).Select(index => new UserDto
            {
                Id = index,
                Name = Users[index],
                Email = Users[index] + "@wanadoo.fr"
            })
            .ToArray();
        }
    }
}