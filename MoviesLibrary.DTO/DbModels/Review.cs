using System.ComponentModel.DataAnnotations;

namespace MoviesLibrary.Models.DbModels
{
    public class Review
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(500)]
        public string Text { get; set; } = null!;

        public int MovieId { get; set; }

        public Movie Movie { get; set; } = null!;
    }
}