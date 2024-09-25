using Business.Services;
using Microsoft.AspNetCore.Mvc;
using Dtos;
using Dtos.Mappers;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController
    {
        /// <summary>
        /// The user service.
        /// </summary>
        private readonly UserService _userService;
        
        public UserController(UserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(UserService));
        }

        [HttpGet("all", Name = "GetAllUsers")]
        public async Task<IEnumerable<UserDto>> GetAllUserAsync(CancellationToken cancellationToken = default)
        {
            var users = await _userService.GetAllUsers(cancellationToken);
            return UserMapper.ToDto(users);
        }
    }
}
