using Microsoft.EntityFrameworkCore;
using PiorFilme.Api.Models;

namespace PiorFilme.Api.Context;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<Movie> Movies { get; set; }
}