namespace PiorFilme.Api.Models;

public class Movie
{
    public Guid Id { get; set; }
    public int Year { get; set; }
    public string Title { get; set; } = default!;
    public string Studios { get; set; } = default!;
    public string Producers { get; set; } = default!;
    public bool Winner { get; set; }
}