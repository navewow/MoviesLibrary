using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using MoviesLibrary.Dal.Context;
using MoviesLibrary.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MoviesLibrary.Dal.Repository
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly MovieDbContext _dbContext;

        public MoviesRepository(MovieDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Movie>> GetMovies(Expression<Func<Movie, bool>>? predicate = null, Func<IQueryable<Movie>, IIncludableQueryable<Movie, object>>? include = null)
        {
            var query = _dbContext.Movies.AsQueryable();

            if (predicate != null)
            { 
                query = query.Where(predicate);
            }

            if (include != null)
            {
                query = include(query).AsSplitQuery();
            }

            return await query.ToListAsync();
        }
    }
}
