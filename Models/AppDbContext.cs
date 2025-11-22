using Microsoft.EntityFrameworkCore;

namespace IT3045C_final.Models
{ 
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<TeamInfo> TeamInfo { get; set; }
        public DbSet<FavoriteVideoGame> FavoriteVideoGames { get; set; }

        public DbSet<FavoriteMovie> FavoriteMovies { get; set; }
        public DbSet<FavoriteGenreOfMusic> FavoriteGenresOfMusic { get; set; }

        // TODO: Add DbSet properties for other models as needed
    }
}