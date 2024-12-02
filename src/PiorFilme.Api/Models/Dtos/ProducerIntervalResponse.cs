using System.Text.Json.Serialization;

namespace PiorFilme.Api.Models.Dtos;

public class ProducerIntervalResponse
{
    [JsonPropertyName("producer")]
    public string Producer { get; set; }
    [JsonPropertyName("interval")]
    public int Interval { get; set; }
    [JsonPropertyName("previousWin")]
    public int PreviousWin { get; set; }
    [JsonPropertyName("followingWin")]
    public int FollowingWin { get; set; }
}