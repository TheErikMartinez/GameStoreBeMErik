using GameStoreBeMErik.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStoreBeMErik.Context
{
    public class GameStoreContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<VideoGame> VideoGames { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(
        //        @"Server=(localdb)\mssqllocaldb;Database=GameStore;Trusted_Connection=True");
        //}
    }
}
