using GameStore.Models.Database;
using System.Data.Entity;

namespace GameStore.Database
{
    public class GamesDb : DbContext
    {
        public DbSet<Game> Games { get; set; }
    }
}
