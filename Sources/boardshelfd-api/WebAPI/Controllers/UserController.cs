using Microsoft.AspNetCore.Mvc;
using Dtos;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController
    {
        private static readonly string[] users =
        {
            "user0", "User1", "User2", "User3", "User4"
        };

        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpGet("all", Name = "GetAllUsers")]
        public IEnumerable<UserDto> Get()
        {
            return Enumerable.Range(0, users.Length).Select(index => new UserDto
            {
                Id = index,
                Name = users[index],
                Email = users[index] + "@wanadoo.fr"
            })
            .ToArray();
        }
    }
}
