using Microsoft.EntityFrameworkCore;
using VideogamesManagement.DataLayer.Entitites;

namespace VideogamesManagement.DataLayer.DB_Context
{
    public class VideoGamesContext : DbContext
    {
        
        public VideoGamesContext() { }
        public DbSet<VideoGame> VideoGames { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Set your own connection string
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-I3P814Q\\SQLEXPRESS;Initial Catalog=Videogames;Integrated Security=True; TrustServerCertificate=True");
        }
    }
}

