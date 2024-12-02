using Microsoft.AspNetCore.Mvc;
using PiorFilme.Api.Mappers;
using PiorFilme.Api.Services.Abstraction;

namespace PiorFilme.Api.Controllers;

[Route("api/movies")]
[ApiController]
public class MoviesController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get(
        [FromServices] IMovieService movieService
    )
    {
        var winningPrizeRange = await movieService.GetPrizeRange();
        return Ok(winningPrizeRange.MovieResponseDto());
    }
}