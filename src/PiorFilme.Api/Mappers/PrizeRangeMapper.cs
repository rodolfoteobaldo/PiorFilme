using PiorFilme.Api.Models;
using PiorFilme.Api.Models.Dtos;

namespace PiorFilme.Api.Mappers;

public static class PrizeRangeMapper
{
    public static PrizeRangeResponse MovieResponseDto(this WinningPrizeRange winningPrizeRange) =>
        new()
        {
            Min = GetAllProducerIntervalResponse(winningPrizeRange.Min),
            Max = GetAllProducerIntervalResponse(winningPrizeRange.Max)
        };

    private static IEnumerable<ProducerIntervalResponse> GetAllProducerIntervalResponse(IEnumerable<WinningProducer> winningProducers)
    {
        var result = new List<ProducerIntervalResponse>();
        foreach (var winningProducer in winningProducers) 
            result.AddRange(winningProducer.ToProducerIntervalResponse());
        return result;
    }
    
    private static IEnumerable<ProducerIntervalResponse> ToProducerIntervalResponse(this WinningProducer winningProducer)
    {
        return winningProducer.Intervals.Select(interval => new ProducerIntervalResponse
        {
            Interval = interval.Interval,
            PreviousWin = interval.StartYear,
            FollowingWin = interval.EndYear,
            Producer = winningProducer.Producer
        });
    }
}