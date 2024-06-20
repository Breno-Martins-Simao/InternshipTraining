using GameStore.Interfaces;
using GameStore.Models.API;
using GameStore.Models.DataBase;

namespace GameStore.Services
{
    public class GamesService : IGameService
    {
        private readonly IGameRepository _GameRepository;

        public GamesService(IGameRepository gameRepository)
        {
            _GameRepository = gameRepository;
        }

        public IEnumerable<Game>? GetAllGames()
        {
            return _GameRepository.GetAllGames();
        }

        public Game? GetGameByID(Guid id)
        {
            return _GameRepository.GetGameByID(id);
        }

        public Game AddGame(GameRequest game)
        {
            return _GameRepository.AddGame(game);
        }

        public Game? UpdateGame(Guid id, GameRequest game)
        {
            return _GameRepository.UpdateGame(id, game);
        }
        public Game? DeleteGame(Guid id)
        {
            return _GameRepository.DeleteGame(id);
        }

    }
}

