using MoviesLibrary.Dal.Context;
using MoviesLibrary.Dal.Initializer;

namespace MoviesLibrary.Extentions
{
    internal static class DbInitializer
    {
        public static IApplicationBuilder SeedMoviesDb(this IApplicationBuilder app)
        {
            ArgumentNullException.ThrowIfNull(app, nameof(app));

            using var scope = app.ApplicationServices.CreateScope();
            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<MovieDbContext>();
                MoviesInitializer.Initialize(context);
            }
            catch (Exception)
            {

            }

            return app;
        }
    }
}
