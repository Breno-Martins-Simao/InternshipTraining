using GameStore.Interfaces;
using GameStore.Models.API;
using GameStore.Models.DataBase;
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
        public ActionResult<IEnumerable<GameRequest>> PutGame(string id, GameRequest game)
        {
            var translate = Guid.TryParse(id, out var gameId);
            if (!translate)
            {
                return BadRequest();
            }
            var gameUpdated = _GameService.UpdateGame(gameId, game);
            return gameUpdated is not null ? Ok(gameUpdated) : NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<GameRequest> DeleteGame(string id)
        {
            var translate = Guid.TryParse (id, out var gameId);
            if (!translate)
            {
                return BadRequest();
            }
            var gameDeleted = _GameService.DeleteGame(gameId);
            return gameDeleted is not null ? Ok(gameDeleted) : NoContent();
        }
    }
}