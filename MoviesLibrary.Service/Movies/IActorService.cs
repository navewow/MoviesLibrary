using MoviesLibrary.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesLibrary.Service.Movies
{
    public interface IActorService
    {
        Task<List<ActorMoviesDto>> GetAllActorMovies();
        Task<ActorMoviesDto> GetActorMoviesbyActorId(int id);
    }
}
