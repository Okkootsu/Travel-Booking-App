using Microsoft.Extensions.DependencyInjection;

namespace TravelApp.Infrastructure.Persistence.Seed;

public static class DatabaseSeederExtensions
{
    public static async Task SeedAccommodationDataAsync(
        this IServiceProvider serviceProvider,
        CancellationToken cancellationToken = default)
    {
        await using var scope = serviceProvider.CreateAsyncScope();
        var seeder = scope.ServiceProvider.GetRequiredService<AccommodationDataSeeder>();
        await seeder.SeedAsync(cancellationToken);
    }
}
