using GameStore.Models.API;

namespace GameStore.Interfaces
{
    public interface IGameService
    {
        IEnumerable<Game> GetAllGames();
        IEnumerable<Game> GetGamesByName(string game);
        Game AddGame(Game game);
        Game UpdateGame(Game game);
        bool DeleteGame(Game game);
    }
}
