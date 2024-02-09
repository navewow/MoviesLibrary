using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MoviesLibrary.Dal.Repository;
using MoviesLibrary.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesLibrary.Service.Movies
{
   
    public class MoviesService : IMoviesService
    {
        private readonly IMapper mapper; 
        private readonly IMoviesRepository moviesRepository;
        public MoviesService(IMapper mapper, IMoviesRepository moviesRepository)
        {
            this.mapper = mapper;
            this.moviesRepository = moviesRepository;
        }

        public async Task<MovieDetailsDto> GetMovieDetails(int id)
        {
            var moviesDb = await moviesRepository.GetMovies(m => m.Id.Equals(id), i => i.Include(i => i.Actors)
            .Include(i => i.Awards)
            .Include(i => i.Director)
            .Include(i => i.Genres)
            .Include(i => i.Reviews)
            );

            return mapper.Map<MovieDetailsDto>(moviesDb.FirstOrDefault());
        }
    }
}
