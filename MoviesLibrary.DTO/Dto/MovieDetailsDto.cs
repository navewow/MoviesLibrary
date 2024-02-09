using MoviesLibrary.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesLibrary.Models.Dto
{
    public class MovieDetailsDto
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required DirectorDto Director { get; set; }

        public required List<ActorDto> Actors { get; set; }

        public List<ReviewDto>? Reviews { get; set; }

        public List<AwardDto>? Awards { get; set; }

        public required List<GenreDto> Genres { get; set; }


    }
}
