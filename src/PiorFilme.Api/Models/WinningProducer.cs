namespace PiorFilme.Api.Models;

public class WinningProducer
{
    public string Producer { get; set; }
    public IList<WinningInterval> Intervals { get; set; }
}