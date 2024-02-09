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
    public interface IGenreRepository
    {
        public Task<List<Genre>> GetGenre(Expression<Func<Genre, bool>>? predicate, Func<IQueryable<Genre>, IIncludableQueryable<Genre, object>>? include);
    }
}
