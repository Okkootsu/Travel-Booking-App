using TravelApp.Domain.Common;
using TravelApp.Domain.Enums;
using TravelApp.Domain.Exceptions;

namespace TravelApp.Domain.Entities;

public class Amenity : AggregateRoot
{
    public string Code { get; private set; } = null!;
    public string Name { get; private set; } = null!;
    public AmenityCategory Category { get; private set; }
    public AmenityScope Scope { get; private set; }
    public string IconKey { get; private set; } = null!;

    private Amenity() { }

    public Amenity(
        string code,
        string name,
        AmenityCategory category,
        AmenityScope scope,
        string iconKey)
    {
        Update(code, name, category, scope, iconKey);
    }

    public void Update(
        string code,
        string name,
        AmenityCategory category,
        AmenityScope scope,
        string iconKey)
    {
        if (string.IsNullOrWhiteSpace(code))
            throw new DomainException("Amenity code is required.");

        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("Amenity name is required.");

        if (string.IsNullOrWhiteSpace(iconKey))
            throw new DomainException("Amenity icon key is required.");

        Code = code.Trim().ToLowerInvariant();
        Name = name.Trim();
        Category = category;
        Scope = scope;
        IconKey = iconKey.Trim().ToLowerInvariant();
        UpdatedAtUtc = DateTime.UtcNow;
    }
}
