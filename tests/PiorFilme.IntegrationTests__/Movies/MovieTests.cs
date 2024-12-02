using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace PiorFilme.IntegrationTests.Movies;

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
        //Act
        var response = await _httpClient.GetAsync($"/movies");
        
        //Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}