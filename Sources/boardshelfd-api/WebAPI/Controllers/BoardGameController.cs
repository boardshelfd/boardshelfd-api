using Microsoft.AspNetCore.Mvc;
using BoardGameGeekClient;
using Dtos;
using BoardGameGeekClient.Model;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("boardgame")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class BoardGameController
    {

        /// <summary>
        /// The user service.
        /// </summary>
        private readonly BoardGameGeekService _gameService;

        public BoardGameController(BoardGameGeekService gameService)
        {
            _gameService = gameService ?? throw new ArgumentNullException(nameof(BoardGameGeekService));
        }

        [HttpGet("id/{gameId}", Name = "GetGameById")]
        [ProducesResponseType<GameDetails>(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetGameByIdAsync(int gameId)
        {
            var game = await _gameService.GetGameByIdAsync(gameId);
            return game == null ? new NotFoundResult() : new OkObjectResult(game);
        }

        [HttpGet("search/{gameName}", Name = "GetGameByName")]
        [ProducesResponseType<IEnumerable<Game>>(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetGameByNameAsync(string gameName)
        {
            var game = await _gameService.GetGameByNameAsync(gameName);
            return game == null ? new NotFoundResult() : new OkObjectResult(game);
        }

        [HttpGet("hot/", Name = "GetHotGames")]
        [ProducesResponseType<IEnumerable<Game>>(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetHotGameAsync()
        {
            var game = await _gameService.GetHotGameAsync();
            return game == null ? new NotFoundResult() : new OkObjectResult(game);
        }
    }
}
