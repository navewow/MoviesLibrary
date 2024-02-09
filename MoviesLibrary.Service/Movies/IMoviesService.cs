using MoviesLibrary.Models.Dto;

namespace MoviesLibrary.Service.Movies
{
    public interface IMoviesService
    {
        Task<MovieDetailsDto> GetMovieDetails(int id);
    }
}
