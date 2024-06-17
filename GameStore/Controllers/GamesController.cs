using GameStore.Interfaces;
using GameStore.Models.API;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GamesController : ControllerBase
    {
        private readonly IGameService _GameService;

        public GamesController(IGameService gameService)
        {
            _GameService = gameService;
        }

        [HttpPost]
        public ActionResult<GameRequest> PostGame([FromBody] GameRequest game)
        {
            var createdGame = _GameService.AddGame(game);
            return CreatedAtAction(nameof (PostGame),game);
        }

        [HttpGet]
        public ActionResult<IEnumerable<GameRequest>> GetAllGames()
        {
            try
            {
                var result = _GameService.GetAllGames();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving games:");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<GameRequest> GetGameByID(string id)
        {
            var translate = Guid.TryParse(id, out var gameId);
            if (!translate)
            {
                return BadRequest();
            }
            var result = _GameService.GetGameByID(gameId);
            return result is not null ? Ok(result) : NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutGame(int id, GameRequest updatedGame)
        {
            if (id != updatedGame.Id)
            {
                return BadRequest("The game ID in the URL does not match the game ID in the body.");
            }

            try
            {
                var existingGame = await _GameService.GetGameByID(id);
                if (existingGame == null)
                {
                    return NotFound("Game not found");
                }

                existingGame.Title = updatedGame.Title;
                existingGame.Genre = updatedGame.Genre;

                await _GameService.UpdateGame(existingGame);
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(500, "A concurrency error occurred while updating the game. Please try again.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating the game with id {id}: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGame(int id)
        {
            try
            {
                var game = await _GameService.GetGameByID(id);
                if (game == null)
                {
                    return NotFound("Game not found");
                }

                await _GameService.DeleteGame(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting the game with id {id}: {ex.Message}");
            }
        }

        private async Task<bool> GameExists(int id)
        {
            return await _GameService.GetGameByID(id) != null;
        }
    }
}