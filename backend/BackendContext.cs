﻿using Microsoft.EntityFrameworkCore;

namespace backend
{
    public class BackendContext : DbContext
    {
        public DbSet<Summary> Summaries { get; set; }

        public BackendContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Summary>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<Summary>()
                .HasData(
                    new Summary { Id = 1, Name = "Freezing" },
                    new Summary { Id = 2, Name = "Bracing" },
                    new Summary { Id = 3, Name = "Chilly" },
                    new Summary { Id = 4, Name = "Cool" },
                    new Summary { Id = 5, Name = "Mild" },
                    new Summary { Id = 6, Name = "Warm" },
                    new Summary { Id = 7, Name = "Balmy" },
                    new Summary { Id = 8, Name = "Hot" },
                    new Summary { Id = 9, Name = "Sweltering" },
                    new Summary { Id = 10, Name = "Scorching" }
                );
        }
    }
}