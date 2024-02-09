using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using MoviesLibrary.Dal.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging.Console;
using MoviesLibrary.Dal.Initializer;
using MoviesLibrary.Extentions;
using System.Text.Json.Serialization;
using MoviesLibrary.Dal.Repository;
using MoviesLibrary.Service.Movies;
using MoviesLibrary.Models.Mapper;
using MoviesLibrary.Middlewares;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddLogging();

builder.Services.AddDbContext<MovieDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("MoviesDbConnection")));
builder.Services.AddScoped<MoviesInitializer>();
builder.Services.AddAutoMapper(typeof(MovieProfile));

builder.Services.AddScoped<IMoviesService, MoviesService>();
builder.Services.AddScoped<IActorService, ActorService>();
builder.Services.AddScoped<IGenreService, GenreService>();

builder.Services.AddScoped<IMoviesRepository, MoviesRepository>();
builder.Services.AddScoped<IActorRepository, ActorRepository>();
builder.Services.AddScoped<IGenreRepository, GenreRepository>();

builder.Services.AddProblemDetails();

var app = builder.Build();

app.Logger.LogInformation("Adding Routes");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.SeedMoviesDb();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GlobalExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
