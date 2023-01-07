using Microsoft.EntityFrameworkCore;
using VotingApp.Entities;

namespace VotingApp.Data
{
    public class VotingAppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = C:\\Users\\HP\\OneDrive\\Desktop\\VotingApp\\VotingApp\\VotingDB.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasData(
                new Category { Id = 1, CategoryName = "Film", Vote = 0 },
                new Category { Id = 2, CategoryName = "Tech Stack", Vote = 0 },
                new Category { Id = 3, CategoryName = "Spor", Vote = 0 },
                new Category { Id = 4, CategoryName = "Music", Vote = 0 }
                );
        }
    }
}
