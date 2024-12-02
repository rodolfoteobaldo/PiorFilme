using PiorFilme.Api.Models;

namespace PiorFilme.Api.Repositories.Abstraction;

public interface IMovieRepository
{
    Task<IEnumerable<Movie>> GetAllWinners();
}