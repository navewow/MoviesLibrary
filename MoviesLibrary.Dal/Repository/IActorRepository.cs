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
    public interface IActorRepository
    {
        public Task<List<Actor>> GetActor(Expression<Func<Actor, bool>>? predicate, Func<IQueryable<Actor>, IIncludableQueryable<Actor, object>>? include);
    }
}
