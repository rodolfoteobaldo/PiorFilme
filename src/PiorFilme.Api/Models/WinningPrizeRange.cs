namespace PiorFilme.Api.Models;

public class WinningPrizeRange
{
    public IEnumerable<WinningProducer> Min { get; set; }
    public IEnumerable<WinningProducer> Max { get; set; }
}