using AutoMapper;
using MoviesLibrary.Models.DbModels;
using MoviesLibrary.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesLibrary.Models.Mapper
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            
            // .ForMember(dest => dest.Reviews, map => map.MapFrom(src => src.Reviews))


            CreateMap<MovieDetailsDto, Movie>().ReverseMap();
            CreateMap<ActorMoviesDto, Actor>().ReverseMap();
            CreateMap<GenreMoviesDto, Genre>().ReverseMap();

            CreateMap<ActorDto, Actor>().ReverseMap();
            CreateMap<DirectorDto,Director>().ReverseMap();
            CreateMap<GenreDto,Genre>().ReverseMap();
            CreateMap<ReviewDto,Review>().ReverseMap();
            CreateMap<AwardDto, Award>().ReverseMap();
            CreateMap<MoviesDto, Movie>().ReverseMap();
        }
    }
}
