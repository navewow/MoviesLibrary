using MoviesLibrary.Dal.Context;
using MoviesLibrary.Models.DbModels;

namespace MoviesLibrary.Dal.Initializer
{
    public class MoviesInitializer
    {
        public static void Initialize(MovieDbContext dbContext)
        {
            dbContext.Database.EnsureCreated();
            if (dbContext.Movies.Any()) return;

            var actor1 = new Actor { Name = "Actor1" };
            var actor2 = new Actor { Name = "Actor2" };

            var director1 = new Director { Name = "Director1" };
            var director2 = new Director { Name = "Director2" };

            var genre1 = new Genre { Name = "Genre1" };
            var genre2 = new Genre { Name = "Genre2" };

            var review1 = new Review { Text = "Review1" };
            var review2 = new Review { Text = "Review2" };

            var award1 = new Award { Name = "Award1" };
            var award2 = new Award { Name = "Award2" };

            var movie1 = new Movie {
               
                Title = "Movie1",
                Actors = new List<Actor> {
                    actor1, actor2
                },
                Awards = new List<Award> {
                    award2
                },
                Director = director1,
                Genres = new List<Genre> {
                    genre1, genre2
                }
            };

            var movie2 = new Movie
            {
               
                Title = "Movie2",
                Actors = new List<Actor> {
                    actor1, actor2
                },
                Awards = new List<Award> {
                    award2
                },
                Director = director1,
                Genres = new List<Genre> {
                    genre1, genre2
                }
            };

            review1.Movie = movie1;

            review2.Movie = movie2;

            dbContext.Actors.AddRange(actor1, actor2);
            dbContext.Directors.AddRange(director1, director2);
            dbContext.Genres.AddRange(genre1, genre2);
            dbContext.Reviews.AddRange(review1, review2);
            dbContext.Awards.AddRange(award1, award2);
            dbContext.Movies.AddRange(movie1, movie2);

            dbContext.SaveChanges();
        }
    }
}
