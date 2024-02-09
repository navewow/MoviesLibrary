using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesLibrary.Dal.Context
{
    public class MovieDbContextFactory : IDesignTimeDbContextFactory<MovieDbContext>
    {
        public MovieDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MovieDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=MoviesDb;Trusted_Connection=True;TrustServerCertificate=True");

            return new MovieDbContext(optionsBuilder.Options);
        }
    }
}
