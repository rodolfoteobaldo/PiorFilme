using PiorFilme.Api.Models;

namespace PiorFilme.Api.Context.SeedData;

public class DbInitializer
{
    public static void Initialize(DataContext dbContext)
    {
        dbContext.Database.EnsureCreated();

        var currentDirectory = Directory.GetCurrentDirectory();
        var fullPath = Path.Combine(currentDirectory, "Context/SeedData", "movies.csv");

        using var reader = new StreamReader(fullPath);
        while (reader.Peek() >= 0)
        {
            var lineMovies = reader.ReadLine();
            if (lineMovies!.StartsWith("year"))
                continue;
            
            var fields = lineMovies.Split(";");
            var newMovie = new Movie
            {
                Year = int.Parse(fields[0]),
                Title = fields[1],
                Studios = fields[2],
                Producers = fields[3],
                Winner = fields[4] == "yes",
            };
            
            dbContext.Movies.Add(newMovie);
        }
        
        dbContext.SaveChanges();
    }
}