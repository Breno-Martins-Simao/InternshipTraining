using GameStore.Interfaces;
using GameStore.Models.API;

namespace GameStore.Services
{
    public class GamesService : IGameService
    {
        private readonly IGameRepository _GameRepository;

        public GamesService(IGameRepository gameRepository)
        {
            _GameRepository = gameRepository;
        }

        public async Task<IEnumerable<Game>> GetAllGames()
        {
            return await _GameRepository.GetAllGames();
        }

        public async Task<Game> GetGamesByID(int id)
        {
            return await _GameRepository.GetGamesByID(id);
        }

        public async Task AddGame(Game game)
        {
            await _GameRepository.AddGame(game);
        }

        public async Task UpdateGame(Game game)
        {
            await _GameRepository.UpdateGame(game);
        }
        public async Task DeleteGame(int id)
        {
            await _GameRepository.DeleteGame(id);
        }
    }
}

