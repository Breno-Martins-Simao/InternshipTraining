using GameStore.Interfaces;
using GameStore.Models.API;

namespace GameStore.Services
{
    public class GamesService : IGameService
    {
        private static List<Game> _GamesDb = new List<Game>();
        private readonly ILogger<GamesService> _Logger;

        public GamesService(ILogger<GamesService> logger) 
        { 
            _Logger = logger;
        }

        public Game AddGame(Game game)
        {
            _GamesDb.Add(game);
            return game;
        }

        public bool DeleteGame(Game game)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Game> GetAllGames()
        {
            return _GamesDb;
        }

        public IEnumerable<Game> GetGamesByName(string game)
        {
            throw new NotImplementedException();
        }

        public Game UpdateGame(Game game)
        {
            throw new NotImplementedException();
        }
    }
}
