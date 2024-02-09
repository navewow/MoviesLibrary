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
    public class ActorRepository : IActorRepository
    {
        private readonly MovieDbContext _dbContext;

        public ActorRepository(MovieDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Actor>> GetActor(Expression<Func<Actor, bool>>? predicate, Func<IQueryable<Actor>, IIncludableQueryable<Actor, object>>? include)
        {
            var query = _dbContext.Actors.AsQueryable();

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
