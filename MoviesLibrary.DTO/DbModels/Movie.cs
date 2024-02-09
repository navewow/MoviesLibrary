using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesLibrary.Models.DbModels
{
    [Index(nameof(Title), IsUnique = true)]
    public class Movie
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = null!;

        public int DirectorId { get; set; }
        
        public Director Director { get; set; } = null!;
        
        public List<Actor> Actors { get; set; } = new List<Actor>();
        
        public List<Genre> Genres { get; set; } = new List<Genre>();

        public List<Review> Reviews { get; set; } = new List<Review>();

        public List<Award> Awards { get; set; } = new List<Award>();

    }
}
