using TravelApp.Domain.Common;
using TravelApp.Domain.Exceptions;
using TravelApp.Domain.ValueObjects;

namespace TravelApp.Domain.Entities;

public class RoomType : BaseEntity
{
    private readonly List<RoomTypeAmenity> _roomTypeAmenities = new();

    public Guid HotelId { get; private set; }
    public string Name { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    public Occupancy Occupancy { get; private set; } = null!;
    public int? SizeSqm { get; private set; }
    public string BedConfiguration { get; private set; } = null!;
    public Money BaseNightlyPrice { get; private set; } = null!;
    public int TotalRoomCount { get; private set; }
    public bool IsActive { get; private set; } = true;

    public IReadOnlyCollection<RoomTypeAmenity> RoomTypeAmenities => _roomTypeAmenities.AsReadOnly();

    private RoomType() { }

    internal RoomType(
        Guid hotelId,
        string name,
        string description,
        Occupancy occupancy,
        string bedConfiguration,
        Money baseNightlyPrice,
        int totalRoomCount,
        int? sizeSqm = null)
    {
        if (hotelId == Guid.Empty)
            throw new DomainException("HotelId is required.");

        HotelId = hotelId;
        UpdateDetails(name, description, occupancy, bedConfiguration, baseNightlyPrice, totalRoomCount, sizeSqm);
    }

    internal void UpdateDetails(
        string name,
        string description,
        Occupancy occupancy,
        string bedConfiguration,
        Money baseNightlyPrice,
        int totalRoomCount,
        int? sizeSqm = null)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("RoomType name is required.");

        if (string.IsNullOrWhiteSpace(description))
            throw new DomainException("RoomType description is required.");

        if (string.IsNullOrWhiteSpace(bedConfiguration))
            throw new DomainException("Bed configuration is required.");

        if (baseNightlyPrice is null || baseNightlyPrice.Amount <= 0)
            throw new DomainException("BaseNightlyPrice must be greater than zero.");

        if (totalRoomCount < 1)
            throw new DomainException("TotalRoomCount must be at least 1.");

        if (sizeSqm.HasValue && sizeSqm.Value <= 0)
            throw new DomainException("SizeSqm must be positive when provided.");

        Name = name.Trim();
        Description = description.Trim();
        Occupancy = occupancy ?? throw new DomainException("RoomType occupancy is required.");
        BedConfiguration = bedConfiguration.Trim();
        BaseNightlyPrice = baseNightlyPrice;
        TotalRoomCount = totalRoomCount;
        SizeSqm = sizeSqm;
        UpdatedAtUtc = DateTime.UtcNow;
    }

    internal void SetActive(bool isActive)
    {
        IsActive = isActive;
        UpdatedAtUtc = DateTime.UtcNow;
    }

    internal void AddAmenity(Guid amenityId)
    {
        if (_roomTypeAmenities.Any(a => a.AmenityId == amenityId))
            return;

        _roomTypeAmenities.Add(new RoomTypeAmenity(Id, amenityId));
        UpdatedAtUtc = DateTime.UtcNow;
    }

    internal void RemoveAmenity(Guid amenityId)
    {
        var existing = _roomTypeAmenities.FirstOrDefault(a => a.AmenityId == amenityId);
        if (existing is null)
            return;

        _roomTypeAmenities.Remove(existing);
        UpdatedAtUtc = DateTime.UtcNow;
    }
}
