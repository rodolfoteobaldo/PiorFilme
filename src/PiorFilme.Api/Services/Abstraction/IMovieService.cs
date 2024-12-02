using PiorFilme.Api.Models;

namespace PiorFilme.Api.Services.Abstraction;

public interface IMovieService
{
    Task<WinningPrizeRange> GetPrizeRange();
}