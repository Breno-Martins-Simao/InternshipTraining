using GameStore.Data;
using GameStore.Interfaces;
using GameStore.Models.API;
using GameStore.Models.DataBase;
using GameStore.Services;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly GameDbContext _context;

        public GameRepository(GameDbContext context)
        {
            _context = context;
        }

        public Game AddGame(GameRequest game)
        {
            var newGame = new Game
            {
                Id = Guid.NewGuid(),
                Title = game.Title,
                Platform = game.Platform,  
                Genre = game.Genre,
                ReleaseDate = game.ReleaseDate,
                CreatedAt = DateTime.UtcNow
            };
            _context.Games.Add(newGame);
            _context.SaveChanges();
            return newGame;
        }

        public Game? DeleteGame(Guid id)
        {
            var deletedGame = _context.Games.FirstOrDefault(e => e.Id == id);
            if (deletedGame != null)
            {
                _context.Games.Remove(deletedGame);
                _context.SaveChanges();
            }
            return deletedGame;
        }

        public IEnumerable<Game> GetAllGames()
        {
            var allGames = _context.Games.ToArray();
            return allGames;
        }

        public Game? GetGameByID(Guid id)
        {
            var game = _context.Games.FirstOrDefault(e => e.Id == id);
            return game;
        }

        public Game? UpdateGame(Guid id, GameRequest game)
        {
            var updatedGame = _context.Games.FirstOrDefault(e => e.Id == id);
            if (updatedGame != null)
            {
                updatedGame.Title = game.Title is not null ? game.Title : updatedGame.Title;
                updatedGame.Platform = game.Platform is not null ? game.Platform : updatedGame.Platform;
                updatedGame.Genre = game.Genre is not null ? game.Genre : updatedGame.Genre;
                updatedGame.ReleaseDate = game.ReleaseDate != updatedGame.ReleaseDate ? game.ReleaseDate : updatedGame.ReleaseDate;
                _context.Games.Update(updatedGame);
                _context.SaveChanges();
            }
            return updatedGame;
        }
    }
}
