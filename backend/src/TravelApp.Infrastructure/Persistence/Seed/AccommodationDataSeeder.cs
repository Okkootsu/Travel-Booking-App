using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TravelApp.Domain.Entities;

namespace TravelApp.Infrastructure.Persistence.Seed;

public class AccommodationDataSeeder
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<AccommodationDataSeeder> _logger;

    public AccommodationDataSeeder(
        ApplicationDbContext dbContext,
        ILogger<AccommodationDataSeeder> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task SeedAsync(CancellationToken cancellationToken = default)
    {
        var amenitiesSeeded = await SeedAmenitiesAsync(cancellationToken);
        var destinationsSeeded = await SeedDestinationsAsync(cancellationToken);
        var hotelsSeeded = await SeedHotelsAsync(cancellationToken);

        if (amenitiesSeeded == 0 && destinationsSeeded == 0 && hotelsSeeded == 0)
        {
            _logger.LogInformation("Accommodation catalog already seeded.");
            return;
        }

        _logger.LogInformation(
            "Seeded {AmenityCount} amenities, {DestinationCount} destinations, and {HotelCount} hotels.",
            amenitiesSeeded,
            destinationsSeeded,
            hotelsSeeded);
    }

    private async Task<int> SeedAmenitiesAsync(CancellationToken cancellationToken)
    {
        var existingCodes = await _dbContext.Amenities
            .AsNoTracking()
            .Select(a => a.Code)
            .ToHashSetAsync(StringComparer.OrdinalIgnoreCase, cancellationToken);

        var missing = AccommodationSeedData.CreateAmenities()
            .Where(a => !existingCodes.Contains(a.Code))
            .ToList();

        if (missing.Count == 0)
            return 0;

        await _dbContext.Amenities.AddRangeAsync(missing, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return missing.Count;
    }

    private async Task<int> SeedDestinationsAsync(CancellationToken cancellationToken)
    {
        var existingSlugs = await _dbContext.Destinations
            .AsNoTracking()
            .Select(d => d.Slug)
            .ToHashSetAsync(StringComparer.OrdinalIgnoreCase, cancellationToken);

        var missing = AccommodationSeedData.CreateDestinations()
            .Where(d => !existingSlugs.Contains(d.Slug))
            .ToList();

        if (missing.Count == 0)
            return 0;

        await _dbContext.Destinations.AddRangeAsync(missing, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return missing.Count;
    }

    private async Task<int> SeedHotelsAsync(CancellationToken cancellationToken)
    {
        var existingHotelSlugs = await _dbContext.Hotels
            .AsNoTracking()
            .Select(h => h.Slug)
            .ToHashSetAsync(StringComparer.OrdinalIgnoreCase, cancellationToken);

        var destinationsBySlug = await _dbContext.Destinations
            .AsNoTracking()
            .ToDictionaryAsync(d => d.Slug, StringComparer.OrdinalIgnoreCase, cancellationToken);

        var amenitiesByCode = await _dbContext.Amenities
            .AsNoTracking()
            .ToDictionaryAsync(a => a.Code, StringComparer.OrdinalIgnoreCase, cancellationToken);

        var missingHotels = AccommodationSeedData.CreateHotels(destinationsBySlug, amenitiesByCode)
            .Where(h => !existingHotelSlugs.Contains(h.Slug))
            .ToList();

        if (missingHotels.Count == 0)
            return 0;

        await _dbContext.Hotels.AddRangeAsync(missingHotels, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return missingHotels.Count;
    }
}
