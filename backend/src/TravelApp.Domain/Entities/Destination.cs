using TravelApp.Domain.Common;
using TravelApp.Domain.Exceptions;
using TravelApp.Domain.ValueObjects;

namespace TravelApp.Domain.Entities;

public class Destination : AggregateRoot
{
    public string Name { get; private set; } = null!;
    public string Country { get; private set; } = null!;
    public string CountryCode { get; private set; } = null!;
    public string Slug { get; private set; } = null!;
    public GeoLocation Location { get; private set; } = null!;
    public string? Description { get; private set; }
    public string? ImageUrl { get; private set; }
    public bool IsFeatured { get; private set; }

    private Destination() { }

    public Destination(
        string name,
        string country,
        string countryCode,
        string slug,
        GeoLocation location,
        string? description = null,
        string? imageUrl = null,
        bool isFeatured = false)
    {
        UpdateDetails(name, country, countryCode, slug, location, description, imageUrl);
        IsFeatured = isFeatured;
    }

    public void UpdateDetails(
        string name,
        string country,
        string countryCode,
        string slug,
        GeoLocation location,
        string? description = null,
        string? imageUrl = null)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("Destination name is required.");

        if (string.IsNullOrWhiteSpace(country))
            throw new DomainException("Destination country is required.");

        if (string.IsNullOrWhiteSpace(countryCode) || countryCode.Trim().Length != 2)
            throw new DomainException("CountryCode must be a 2-letter ISO 3166-1 alpha-2 code.");

        if (string.IsNullOrWhiteSpace(slug))
            throw new DomainException("Destination slug is required.");

        Name = name.Trim();
        Country = country.Trim();
        CountryCode = countryCode.Trim().ToUpperInvariant();
        Slug = slug.Trim().ToLowerInvariant();
        Location = location ?? throw new DomainException("Destination location is required.");
        Description = string.IsNullOrWhiteSpace(description) ? null : description.Trim();
        ImageUrl = string.IsNullOrWhiteSpace(imageUrl) ? null : imageUrl.Trim();
        UpdatedAtUtc = DateTime.UtcNow;
    }

    public void SetFeatured(bool isFeatured)
    {
        IsFeatured = isFeatured;
        UpdatedAtUtc = DateTime.UtcNow;
    }
}
