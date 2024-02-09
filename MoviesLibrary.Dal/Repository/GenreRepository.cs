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
    public class GenreRepository : IGenreRepository
    {
        private readonly MovieDbContext _dbContext;

        public GenreRepository(MovieDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Genre>> GetGenre(Expression<Func<Genre, bool>>? predicate, Func<IQueryable<Genre>, IIncludableQueryable<Genre, object>>? include)
        {
            var query = _dbContext.Genres.AsQueryable();

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
