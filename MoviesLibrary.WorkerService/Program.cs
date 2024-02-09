
using Microsoft.EntityFrameworkCore;
using MoviesLibrary.Dal.Context;
using MoviesLibrary.Dal.Repository;
using MoviesLibrary.Models.Mapper;
using MoviesLibrary.Service.Movies;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddDbContext<MovieDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("MoviesDbConnection")));

builder.Services.AddAutoMapper(typeof(MovieProfile));
builder.Services.AddScoped<IActorService, ActorService>();
builder.Services.AddScoped<IGenreService, GenreService>();

builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddScoped<IActorRepository, ActorRepository>();
builder.Services.AddHostedService<MoviesReporterWorker>();


var host = builder.Build();
host.Run();
