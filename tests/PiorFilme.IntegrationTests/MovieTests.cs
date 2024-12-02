using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using PiorFilme.Api.Models.Dtos;

namespace PiorFilme.IntegrationTests;

public class MovieTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public MovieTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task Get_Movies()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync("api/movies");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var responseString = await response.Content.ReadAsStringAsync();
        var prizeRangeResponse = JsonSerializer.Deserialize<PrizeRangeResponse>(responseString);
        Assert.Single(prizeRangeResponse!.Min);
        Assert.Single(prizeRangeResponse!.Max);
        Assert.Equal(6, prizeRangeResponse!.Min.First().Interval); 
        Assert.Equal(13, prizeRangeResponse!.Max.First().Interval); 
    }
}