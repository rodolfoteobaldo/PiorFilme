using Microsoft.EntityFrameworkCore;
using PiorFilme.Api.Context;
using PiorFilme.Api.Models;
using PiorFilme.Api.Repositories.Abstraction;

namespace PiorFilme.Api.Repositories;

public class MovieRepository(DataContext dataContext) : IMovieRepository
{
    public async Task<IEnumerable<Movie>> GetAllWinners()
    {
        return await dataContext.Movies.Where(x => x.Winner).ToListAsync();
    }
}