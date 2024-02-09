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
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _GenreRepository;
        private readonly IMapper _mapper;

        public GenreService( IGenreRepository GenreRepository, IMapper mapper)
        {
            _GenreRepository = GenreRepository;
            _mapper = mapper;

        }

        public async Task<List<GenreDto>> GetAllGenre()
        {
            var genreDb = await _GenreRepository.GetGenre(null, null);

            return _mapper.Map<List<GenreDto>>(genreDb);
        }

        public async Task<List<GenreMoviesDto>> GetAllGenreMovies()
        {
            var genreDb = await _GenreRepository.GetGenre(null, i => i.Include(i => i.Movies));

            return _mapper.Map<List<GenreMoviesDto>>(genreDb);
        }

        public async Task<GenreMoviesDto> GetGenreMoviesbyGenreId(int id)
        {
            var genreDb = await _GenreRepository.GetGenre(m => m.Id.Equals(id), i => i.Include(i => i.Movies));

            return _mapper.Map<GenreMoviesDto>(genreDb.FirstOrDefault());
        }
    }
}
