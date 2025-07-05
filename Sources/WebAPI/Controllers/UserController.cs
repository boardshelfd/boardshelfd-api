using Business.Services;
using Microsoft.AspNetCore.Mvc;
using Dtos;
using Dtos.Mappers;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("user")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
        [ProducesResponseType<IEnumerable<UserDto>>(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllUserAsync(CancellationToken cancellationToken = default)
        {
            var users = await _userService.GetAllUsers(cancellationToken);
            return users == null ? new NotFoundResult() : new OkObjectResult(users.ToDto());
        }

        [HttpGet("id/{userId}", Name = "GetUserById")]
        [ProducesResponseType<UserDto>(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUserByIdAsync(int userId, CancellationToken cancellationToken = default)
        {
            var user = await _userService.GetUserByIdAsync(userId, cancellationToken);
            return user == null ? new NotFoundResult() : new OkObjectResult(user.ToDto());
        }

        [HttpGet("name/{userName}", Name = "GetUsersByName")]
        [ProducesResponseType<IEnumerable<UserDto>>(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUsersByNameAsync(string userName, CancellationToken cancellationToken = default)
        {
            var users = await _userService.GetUsersByNameAsync(userName, cancellationToken);
            return users == null ? new NotFoundResult() : new OkObjectResult(users.ToDto());
        }

        [HttpPost("", Name = "CreateUser")]
        [ProducesResponseType<IEnumerable<UserDto>>(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateUserAsync([FromBody] UserDto user, CancellationToken cancellationToken = default)
        {
            var result = await _userService.CreateUserAsync(user.ToEntity(), cancellationToken);
            return result != 0 ? new CreatedResult(nameof(CreateUserAsync), result) : new BadRequestResult();
        }

        /*
        [HttpDelete("", Name = "DeleteUser")]
        [ProducesResponseType<IEnumerable<UserDto>>(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteUserAsync([FromBody] UserDto user, CancellationToken cancellationToken = default)
        {
            var result = await _userService.DeleteUserAsync(user.ToEntity(), cancellationToken);
            return result != 0 ? new OkObjectResult(result) : new NotFoundResult();
        }

        [HttpDelete("id/{userId}", Name = "DeleteUserFromId")]
        [ProducesResponseType<IEnumerable<UserDto>>(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteUserFromIdAsync(int userId, CancellationToken cancellationToken = default)
        {
            var result = await _userService.DeleteUserFromIdAsync(userId, cancellationToken);
            return result != 0 ? new OkObjectResult(result) : new NotFoundResult();
        }
        */

        [HttpPut("", Name = "UpdateUser")]
        [ProducesResponseType<IEnumerable<UserDto>>(StatusCodes.Status201Created)]
        public async Task<IActionResult> UpdateUserAsync(UserDto user, CancellationToken cancellationToken)
        {
            var result = await _userService.UpdateUserAsync(user.ToEntity(), cancellationToken);
            return result != 0 ? new CreatedResult(nameof(UpdateUserAsync), result) : new NotFoundResult();
        }
    }
}
