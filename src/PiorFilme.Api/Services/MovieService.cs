using PiorFilme.Api.Models;
using PiorFilme.Api.Repositories.Abstraction;
using PiorFilme.Api.Services.Abstraction;

namespace PiorFilme.Api.Services;

public class MovieService(IMovieRepository movieRepository) : IMovieService
{
    public async Task<WinningPrizeRange> GetPrizeRange()
    {
        var winnerProducers = await GetWinningProducers();

        return new WinningPrizeRange
        {
            Min = ShorterInterval(winnerProducers),
            Max = LongestInterval(winnerProducers)
        };
    }
    
    private static IEnumerable<WinningProducer> ShorterInterval(IEnumerable<WinningProducer> winnerProducers)
    {
        var minInterval = winnerProducers
            .SelectMany(p => p.Intervals.Select(i => i.Interval))
            .Min();

        return winnerProducers
            .Where(p => p.Intervals.Any(i => i.Interval == minInterval))
            .Select(p => new WinningProducer
            {
                Producer = p.Producer,
                Intervals = p.Intervals.Where(i => i.Interval == minInterval).ToList()
            })
            .ToList();
    }

    private static IEnumerable<WinningProducer> LongestInterval(IEnumerable<WinningProducer> winnerProducers)
    {
        var maxInterval = winnerProducers
            .SelectMany(p => p.Intervals.Select(i => i.Interval))
            .Max();

        return winnerProducers
            .Where(p => p.Intervals.Any(i => i.Interval == maxInterval))
            .Select(p => new WinningProducer
            {
                Producer = p.Producer,
                Intervals = p.Intervals.Where(i => i.Interval == maxInterval).ToList()
            })
            .ToList();
    }
    
    private async Task<IEnumerable<WinningProducer>> GetWinningProducers()
    {
        var winnerMovies = await movieRepository.GetAllWinners();
        
        var winningProducersQuery = winnerMovies
            .SelectMany(m => m.Producers.Split(", ")
                .Select(producer => new { Producer = producer.Trim(), Year = m.Year }))
            .GroupBy(x => x.Producer)
            .Where(g => g.Count() > 1)
            .Select(g => new
            {
                Producer = g.Key,
                Years = g.Select(x => x.Year).OrderBy(y => y).ToList(),
            })
            .Select(g => new WinningProducer
            {
                Producer = g.Producer,
                Intervals = g.Years.Zip(g.Years.Skip(1), (y1, y2) => new WinningInterval { StartYear = y1, EndYear = y2, Interval = y2 - y1 }).ToList()
            });

        return winningProducersQuery;
    }
}