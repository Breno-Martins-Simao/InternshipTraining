using GameStore.Interfaces;
using GameStore.Models.API;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GameStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GamesController : ControllerBase
    {
        private readonly ILogger<GamesController> _Logger;
        private readonly IGameService _GameService;

        public GamesController(ILogger<GamesController> logger, IGameService gameService)
        {
            _Logger = logger;
            _GameService = gameService;
        }

        [HttpPost()]
        public ActionResult<Game> AddGame([FromBody] Game game)
        {
            _Logger.LogDebug("The API was called");
            _GameService.AddGame(game);
            return Created();
        }


        [HttpGet()]
        public ActionResult<IEnumerable<Game>> GetAllGames()
        {
            _Logger.LogDebug("The API was called");
            var result = _GameService.GetAllGames();
           return Ok(result);
        }
    }
}
