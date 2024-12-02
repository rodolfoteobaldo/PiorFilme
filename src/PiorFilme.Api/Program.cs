using Microsoft.EntityFrameworkCore;
using PiorFilme.Api.Context;
using PiorFilme.Api.Context.SeedData;
using PiorFilme.Api.Repositories;
using PiorFilme.Api.Repositories.Abstraction;
using PiorFilme.Api.Services;
using PiorFilme.Api.Services.Abstraction;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("PioresFilmes"));

builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IMovieService, MovieService>();

var app = builder.Build();

app.SeedData(); 

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

public partial class Program { }
