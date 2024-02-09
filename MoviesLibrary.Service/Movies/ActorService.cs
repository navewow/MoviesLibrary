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
    public class ActorService(IActorRepository actorRepository, IMapper mapper) : IActorService
    {
        private readonly IActorRepository _actorRepository = actorRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<List<ActorMoviesDto>> GetAllActorMovies()
        {
            var actorDb = await _actorRepository.GetActor(null, i => i.Include(i => i.Movies));

            return _mapper.Map<List<ActorMoviesDto>>(actorDb);
        }

        public async Task<ActorMoviesDto> GetActorMoviesbyActorId(int id)
        {
            var actorDb = await _actorRepository.GetActor(m => m.Id.Equals(id), i => i.Include(i => i.Movies));

            return _mapper.Map<ActorMoviesDto>(actorDb.FirstOrDefault());
        }
    }
}
