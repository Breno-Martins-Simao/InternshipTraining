using GameStore.Models.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GameStore.Database
{
    public class GamesDbContext : DbContext
    {
        public GamesDbContext(DbContextOptions<GamesDbContext> options)
        : base(options)
        {}

        public DbSet<Game> Games { get; set; }

    }
}
