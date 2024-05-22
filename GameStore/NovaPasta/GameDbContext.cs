using GameStore.Models.API;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Data
{
    public class GameDbContext : DbContext
    {
        DbSet<Game> Games { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Banco.");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
