using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;

namespace MvcMovie.Data
{
    public class MvcMovieContext : DbContext
    {
        public MvcMovieContext(DbContextOptions<MvcMovieContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movie { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = 1,
                    Title = "The Three Musketeers",
                    ReleaseDate = new DateTime(1993, 1, 1),
                    Genre = "Adventure",
                    Price = 9.99M
                },
                new Movie
                {
                    Id = 2,
                    Title = "Jurassic Park",
                    ReleaseDate = new DateTime(1993, 6, 11),
                    Genre = "Sci-Fi",
                    Price = 12.99M
                },
                new Movie
                {
                    Id = 3,
                    Title = "Romeo and Juliet",
                    ReleaseDate = new DateTime(1996, 11, 1),
                    Genre = "Drama",
                    Price = 7.99M
                }
            );
        }
    }
}
