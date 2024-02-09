using MoviesLibrary.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesLibrary.Service.Movies
{
    public interface IGenreService
    {
        Task<List<GenreDto>> GetAllGenre();
        Task<List<GenreMoviesDto>> GetAllGenreMovies();

        Task<GenreMoviesDto> GetGenreMoviesbyGenreId(int id);
    }
}
