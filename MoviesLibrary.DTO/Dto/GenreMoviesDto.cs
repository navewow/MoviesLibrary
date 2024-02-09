using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesLibrary.Models.Dto
{
    public class GenreMoviesDto : GenreDto
    {
        public List<MoviesDto>? Movies { get; set; }
    }
}
