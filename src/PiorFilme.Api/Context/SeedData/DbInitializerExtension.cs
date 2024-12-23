namespace PiorFilme.Api.Context.SeedData;

internal static class DbInitializerExtension
{
    public static void SeedData(this IApplicationBuilder app)
    {
        ArgumentNullException.ThrowIfNull(app, nameof(app));

        using var scope = app.ApplicationServices.CreateScope();
        var services = scope.ServiceProvider;
        try
        {
            var context = services.GetRequiredService<DataContext>();
            DbInitializer.Initialize(context);
        }
        catch (Exception ex)
        {
            // ignored
        }
    }
}