using Microsoft.EntityFrameworkCore.Query;
using MoviesLibrary.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MoviesLibrary.Dal.Repository
{
    public interface IMoviesRepository
    {
        public Task<List<Movie>> GetMovies(Expression<Func<Movie,bool>>? predicate, Func<IQueryable<Movie>, IIncludableQueryable<Movie, object>>? include);
    }
}
