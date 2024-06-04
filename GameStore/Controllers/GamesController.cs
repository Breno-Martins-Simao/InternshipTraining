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
        public async Task<ActionResult<Game>> PostGame(Game game)
        {
            try
            {
                await _GameService.AddGame(game);
                return CreatedAtAction(nameof(GetGame), new { id = game.Id }, game);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding the game: {ex.Message}");
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<Game>> GetAllGames()
        {
            try
            {
                var result = _GameService.GetAllGames();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving games: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> GetGame(int id)
        {
            try
            {
                var game = await _GameService.GetGamesByID(id);

                if (game == null)
                {
                    return NotFound("Game not found");
                }

                return Ok(game);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving the game with id {id}: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutGame(int id, Game updatedGame)
        {
            if (id != updatedGame.Id)
            {
                return BadRequest("The game ID in the URL does not match the game ID in the body.");
            }

            try
            {
                var existingGame = await _GameService.GetGamesByID(id);
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
                var game = await _GameService.GetGamesByID(id);
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
            return await _GameService.GetGamesByID(id) != null;
        }
    }
}