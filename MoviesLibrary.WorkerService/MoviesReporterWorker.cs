using CsvHelper;
using MoviesLibrary.Models.DbModels;
using MoviesLibrary.Models.Dto;
using MoviesLibrary.Service.Movies;
using MoviesLibrary.WorkerService.Models;
using System.Formats.Asn1;
using System.Globalization;
using System.IO;

public class MoviesReporterWorker : IHostedService, IDisposable
{
    private int executionCount = 0;
    private readonly ILogger<MoviesReporterWorker> _logger;
    private Timer? _timer = null;
    public IServiceProvider Services { get; }

    public MoviesReporterWorker(ILogger<MoviesReporterWorker> logger, IServiceProvider services)
    {
        _logger = logger;
        Services = services;
    }

    public Task StartAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Reports Service running.");

        _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromDays(1));

        return Task.CompletedTask;
    }

    private void DoWork(object? state)
    {
        var count = Interlocked.Increment(ref executionCount);

        _logger.LogInformation(
            "Reports Service is working. Count: {Count}", count);

        Task[] reportTasks = [GenerateActorMoviesReport(), GenerateGenreReport(), GenerateGenreCountReport()];

        Task.WaitAll(reportTasks);

    }

    private async Task GenerateActorMoviesReport() 
    {
        using (var scope = Services.CreateScope())
        {
            var actorService = scope.ServiceProvider.GetRequiredService<IActorService>();

            var moviesByActors = await actorService.GetAllActorMovies();

            string path = Path.Combine("ReportsOutput", $"Actor_Movies{DateTime.UtcNow.ToFileTime()}.csv");
            ActorMoviesReportSaveAsCsv(moviesByActors, path);
        }
    }

    private async Task GenerateGenreReport()
    {
        using (var scope = Services.CreateScope())
        {
            var genreService = scope.ServiceProvider.GetRequiredService<IGenreService>();

            var moviesByGenres = await genreService.GetAllGenreMovies();

            string path = Path.Combine("ReportsOutput", $"Genre_Movies{DateTime.UtcNow.ToFileTime()}.csv");

            GenreMoviesReportSaveAsCsv(moviesByGenres, path);
        }
    }

    private async Task GenerateGenreCountReport()
    {
        using (var scope = Services.CreateScope())
        {
            var genreService = scope.ServiceProvider.GetRequiredService<IGenreService>();

            var genres = await genreService.GetAllGenre();

            string path = Path.Combine("ReportsOutput", $"Genre_Count{DateTime.UtcNow.ToFileTime()}.csv");

            GenreCountReportSaveAsCsv(genres, path);
        }
    }

    private static void ActorMoviesReportSaveAsCsv(List<ActorMoviesDto> moviesByActors, string path)
    {
        using (var writer = ((File.Exists(path)) ? File.AppendText(path) : File.CreateText(path)))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            csv.WriteHeader<ActorMovieReportCsv>();
            csv.NextRecord();
            foreach (var actorMovie in moviesByActors)
            {
                if (actorMovie.Movies.Count != 0)
                {
                    foreach (var movie in actorMovie.Movies)
                    {
                        csv.WriteField(actorMovie.Id);
                        csv.WriteField(actorMovie.Name);
                        csv.WriteField(movie.Id);
                        csv.WriteField(movie.Title);
                        csv.NextRecord();
                    }
                }
                else
                {
                    csv.WriteField(actorMovie.Id);
                    csv.WriteField(actorMovie.Name);
                    csv.NextRecord();
                }
            }

            writer.Flush();
        }
    }

    private static void GenreMoviesReportSaveAsCsv(List<GenreMoviesDto> moviesByGenre, string path)
    {
        using (var writer = ((File.Exists(path)) ? File.AppendText(path) : File.CreateText(path)))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            csv.WriteHeader<GenreMovieReportCsv>();
            csv.NextRecord();
            foreach (var genreMovie in moviesByGenre)
            {
                if (genreMovie.Movies.Count != 0)
                {
                    foreach (var movie in genreMovie.Movies)
                    {
                        csv.WriteField(genreMovie.Id);
                        csv.WriteField(genreMovie.Name);
                        csv.WriteField(movie.Id);
                        csv.WriteField(movie.Title);
                        csv.NextRecord();
                    }
                }
                else
                {
                    csv.WriteField(genreMovie.Id);
                    csv.WriteField(genreMovie.Name);
                    csv.NextRecord();
                }
            }
            writer.Flush();
        }
    }

    private static void GenreCountReportSaveAsCsv(List<GenreDto> genres, string path)
    {
        using (var writer = ((File.Exists(path)) ? File.AppendText(path) : File.CreateText(path)))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            csv.WriteHeader<GenreCountReportCsv>();
            csv.NextRecord();
            var genereCountData = genres.GroupBy(x => x.Id).Select((key, g) => new GenreCountReportCsv {
                GenreId = key.Key,
                Count = key.Count(),
                Name = key.First().Name
            }).ToList();

            csv.WriteRecords(genereCountData);
            writer.Flush();
        }
    }

    public Task StopAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Reports Worker service stopped.");

        _timer?.Change(Timeout.Infinite, 0);

        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _timer?.Dispose();
    }
}