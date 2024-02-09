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
    public class GenreService(IGenreRepository genreRepository, IMapper mapper) : IGenreService
    {
        public async Task<List<GenreDto>> GetAllGenre()
        {
            var genreDb = await genreRepository.GetGenre(null, null);

            return mapper.Map<List<GenreDto>>(genreDb);
        }

        public async Task<List<GenreMoviesDto>> GetAllGenreMovies()
        {
            var genreDb = await genreRepository.GetGenre(null, i => i.Include(i => i.Movies));

            return mapper.Map<List<GenreMoviesDto>>(genreDb);
        }

        public async Task<GenreMoviesDto> GetGenreMoviesbyGenreId(int id)
        {
            var genreDb = await genreRepository.GetGenre(m => m.Id.Equals(id), i => i.Include(i => i.Movies));

            return mapper.Map<GenreMoviesDto>(genreDb.FirstOrDefault());
        }
    }
}
