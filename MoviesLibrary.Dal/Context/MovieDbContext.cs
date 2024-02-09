using Microsoft.EntityFrameworkCore;
using MoviesLibrary.Models.DbModels;
using System.IO;

namespace MoviesLibrary.Dal.Context
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies{ get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Award> Awards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().ToTable("Movie");
            modelBuilder.Entity<Actor>().ToTable("Actor");
            modelBuilder.Entity<Director>().ToTable("Director");
            modelBuilder.Entity<Genre>().ToTable("Genre");
            modelBuilder.Entity<Review>().ToTable("Review");
            modelBuilder.Entity<Award>().ToTable("Award");
        }
    }
}
