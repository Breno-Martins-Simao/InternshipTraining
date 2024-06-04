﻿using GameStore.Models.API;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Data
{
    public class GameDbContext : DbContext
    {
        public GameDbContext(DbContextOptions<GameDbContext> options) : base(options)
        {
        }

        public DbSet<Game> Games { get; set; }
    }
}
