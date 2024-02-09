using MoviesLibrary.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesLibrary.WorkerService.Models
{
    internal class GenreMovieReportCsv
    {
        public int GenreId { get; set; }
        public required string Name { get; set; }

        public int MovieId { get; set; }
        public required string Title { get; set; }
    }
}
