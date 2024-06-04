using GameStore.Models.API;

namespace GameStore.Interfaces
{
    public interface IGameService
    {
        Task<IEnumerable<Game>> GetAllGames();
        Task<Game> GetGamesByID(int id);
        Task AddGame(Game game);
        Task UpdateGame(Game game);
        Task DeleteGame(int id);
    }

    public interface IGameRepository
    {
        Task<IEnumerable<Game>> GetAllGames();
        Task<Game> GetGamesByID(int id);
        Task AddGame(Game game);
        Task UpdateGame(Game game);
        Task DeleteGame(int id);
    }
}
