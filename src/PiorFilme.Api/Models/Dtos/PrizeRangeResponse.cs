using System.Text.Json.Serialization;

namespace PiorFilme.Api.Models.Dtos;

public class PrizeRangeResponse
{
    [JsonPropertyName("min")]
    public IEnumerable<ProducerIntervalResponse> Min { get; set; }
    
    [JsonPropertyName("max")]
    public IEnumerable<ProducerIntervalResponse> Max { get; set; }
}