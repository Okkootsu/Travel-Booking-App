using TravelApp.Domain.Common;
using TravelApp.Domain.Enums;
using TravelApp.Domain.Exceptions;
using TravelApp.Domain.ValueObjects;

namespace TravelApp.Domain.Entities;

public class Hotel : AggregateRoot
{
    private readonly List<RoomType> _roomTypes = new();
    private readonly List<HotelImage> _images = new();
    private readonly List<HotelAmenity> _hotelAmenities = new();

    public Guid DestinationId { get; private set; }
    public string Name { get; private set; } = null!;
    public string Slug { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    public PropertyType PropertyType { get; private set; }
    public int StarRating { get; private set; }
    public Address Address { get; private set; } = null!;
    public GeoLocation Location { get; private set; } = null!;
    public TimeOnly CheckInTime { get; private set; }
    public TimeOnly CheckOutTime { get; private set; }
    public HotelStatus Status { get; private set; } = HotelStatus.Draft;
    public decimal AverageRating { get; private set; }
    public int ReviewCount { get; private set; }

    public IReadOnlyCollection<RoomType> RoomTypes => _roomTypes.AsReadOnly();
    public IReadOnlyCollection<HotelImage> Images => _images.AsReadOnly();
    public IReadOnlyCollection<HotelAmenity> HotelAmenities => _hotelAmenities.AsReadOnly();

    private Hotel() { }

    public Hotel(
        Guid destinationId,
        string name,
        string slug,
        string description,
        PropertyType propertyType,
        int starRating,
        Address address,
        GeoLocation location,
        TimeOnly? checkInTime = null,
        TimeOnly? checkOutTime = null)
    {
        if (destinationId == Guid.Empty)
            throw new DomainException("DestinationId is required.");

        DestinationId = destinationId;
        UpdateDetails(
            name,
            slug,
            description,
            propertyType,
            starRating,
            address,
            location,
            checkInTime ?? new TimeOnly(14, 0),
            checkOutTime ?? new TimeOnly(12, 0));
    }

    public void UpdateDetails(
        string name,
        string slug,
        string description,
        PropertyType propertyType,
        int starRating,
        Address address,
        GeoLocation location,
        TimeOnly checkInTime,
        TimeOnly checkOutTime)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("Hotel name is required.");

        if (string.IsNullOrWhiteSpace(slug))
            throw new DomainException("Hotel slug is required.");

        if (string.IsNullOrWhiteSpace(description))
            throw new DomainException("Hotel description is required.");

        if (starRating is < 1 or > 5)
            throw new DomainException("StarRating must be between 1 and 5.");

        Name = name.Trim();
        Slug = slug.Trim().ToLowerInvariant();
        Description = description.Trim();
        PropertyType = propertyType;
        StarRating = starRating;
        Address = address ?? throw new DomainException("Hotel address is required.");
        Location = location ?? throw new DomainException("Hotel location is required.");
        CheckInTime = checkInTime;
        CheckOutTime = checkOutTime;
        UpdatedAtUtc = DateTime.UtcNow;
    }

    public RoomType AddRoomType(
        string name,
        string description,
        Occupancy occupancy,
        string bedConfiguration,
        Money baseNightlyPrice,
        int totalRoomCount,
        int? sizeSqm = null)
    {
        var normalizedName = name?.Trim() ?? string.Empty;
        if (_roomTypes.Any(r => string.Equals(r.Name, normalizedName, StringComparison.OrdinalIgnoreCase)))
            throw new DomainException($"A room type named '{normalizedName}' already exists in this hotel.");

        var roomType = new RoomType(
            Id,
            normalizedName,
            description,
            occupancy,
            bedConfiguration,
            baseNightlyPrice,
            totalRoomCount,
            sizeSqm);

        _roomTypes.Add(roomType);
        UpdatedAtUtc = DateTime.UtcNow;
        return roomType;
    }

    public void UpdateRoomType(
        Guid roomTypeId,
        string name,
        string description,
        Occupancy occupancy,
        string bedConfiguration,
        Money baseNightlyPrice,
        int totalRoomCount,
        int? sizeSqm = null)
    {
        var roomType = GetRoomTypeOrThrow(roomTypeId);
        var normalizedName = name?.Trim() ?? string.Empty;

        if (_roomTypes.Any(r => r.Id != roomTypeId && string.Equals(r.Name, normalizedName, StringComparison.OrdinalIgnoreCase)))
            throw new DomainException($"A room type named '{normalizedName}' already exists in this hotel.");

        roomType.UpdateDetails(normalizedName, description, occupancy, bedConfiguration, baseNightlyPrice, totalRoomCount, sizeSqm);
        UpdatedAtUtc = DateTime.UtcNow;
    }

    public void SetRoomTypeActive(Guid roomTypeId, bool isActive)
    {
        var roomType = GetRoomTypeOrThrow(roomTypeId);

        if (!isActive && Status == HotelStatus.Active && _roomTypes.Count(r => r.IsActive && r.Id != roomTypeId) == 0)
            throw new DomainException("An active hotel must have at least one active room type.");

        roomType.SetActive(isActive);
        UpdatedAtUtc = DateTime.UtcNow;
    }

    public void RemoveRoomType(Guid roomTypeId)
    {
        var roomType = GetRoomTypeOrThrow(roomTypeId);

        if (Status == HotelStatus.Active && _roomTypes.Count(r => r.IsActive && r.Id != roomTypeId) == 0)
            throw new DomainException("Cannot remove the last active room type of an active hotel.");

        _roomTypes.Remove(roomType);
        UpdatedAtUtc = DateTime.UtcNow;
    }

    public HotelImage AddImage(
        string url,
        string altText,
        int sortOrder,
        bool isPrimary = false,
        Guid? roomTypeId = null)
    {
        if (roomTypeId.HasValue && _roomTypes.All(r => r.Id != roomTypeId.Value))
            throw new DomainException("Specified RoomTypeId does not belong to this hotel.");

        if (isPrimary)
        {
            foreach (var existing in _images.Where(i => i.IsPrimary))
                existing.SetPrimary(false);
        }

        var image = new HotelImage(Id, url, altText, sortOrder, isPrimary, roomTypeId);
        _images.Add(image);
        UpdatedAtUtc = DateTime.UtcNow;
        return image;
    }

    public void SetPrimaryImage(Guid imageId)
    {
        var target = _images.FirstOrDefault(i => i.Id == imageId)
            ?? throw new DomainException("Image not found in this hotel.");

        foreach (var existing in _images.Where(i => i.IsPrimary && i.Id != imageId))
            existing.SetPrimary(false);

        target.SetPrimary(true);
        UpdatedAtUtc = DateTime.UtcNow;
    }

    public void RemoveImage(Guid imageId)
    {
        var target = _images.FirstOrDefault(i => i.Id == imageId)
            ?? throw new DomainException("Image not found in this hotel.");

        if (Status == HotelStatus.Active && _images.Count == 1)
            throw new DomainException("Cannot remove the last image of an active hotel.");

        var wasPrimary = target.IsPrimary;
        _images.Remove(target);

        if (wasPrimary && _images.Count > 0)
        {
            _images.OrderBy(i => i.SortOrder).First().SetPrimary(true);
        }

        UpdatedAtUtc = DateTime.UtcNow;
    }

    public void AddAmenity(Guid amenityId)
    {
        if (_hotelAmenities.Any(a => a.AmenityId == amenityId))
            return;

        _hotelAmenities.Add(new HotelAmenity(Id, amenityId));
        UpdatedAtUtc = DateTime.UtcNow;
    }

    public void RemoveAmenity(Guid amenityId)
    {
        var existing = _hotelAmenities.FirstOrDefault(a => a.AmenityId == amenityId);
        if (existing is null)
            return;

        _hotelAmenities.Remove(existing);
        UpdatedAtUtc = DateTime.UtcNow;
    }

    public void AddRoomTypeAmenity(Guid roomTypeId, Guid amenityId)
    {
        var roomType = GetRoomTypeOrThrow(roomTypeId);
        roomType.AddAmenity(amenityId);
        UpdatedAtUtc = DateTime.UtcNow;
    }

    public void RemoveRoomTypeAmenity(Guid roomTypeId, Guid amenityId)
    {
        var roomType = GetRoomTypeOrThrow(roomTypeId);
        roomType.RemoveAmenity(amenityId);
        UpdatedAtUtc = DateTime.UtcNow;
    }

    public void Publish()
    {
        if (!_roomTypes.Any(r => r.IsActive))
            throw new DomainException("Cannot publish a hotel without at least one active room type.");

        if (_images.Count == 0)
            throw new DomainException("Cannot publish a hotel without at least one image.");

        if (!_images.Any(i => i.IsPrimary))
        {
            _images.OrderBy(i => i.SortOrder).First().SetPrimary(true);
        }

        Status = HotelStatus.Active;
        UpdatedAtUtc = DateTime.UtcNow;
    }

    public void Deactivate()
    {
        Status = HotelStatus.Inactive;
        UpdatedAtUtc = DateTime.UtcNow;
    }

    public void UpdateRatingSummary(decimal averageRating, int reviewCount)
    {
        if (averageRating is < 0 or > 5)
            throw new DomainException("AverageRating must be between 0 and 5.");

        if (reviewCount < 0)
            throw new DomainException("ReviewCount cannot be negative.");

        AverageRating = decimal.Round(averageRating, 2, MidpointRounding.AwayFromZero);
        ReviewCount = reviewCount;
        UpdatedAtUtc = DateTime.UtcNow;
    }

    private RoomType GetRoomTypeOrThrow(Guid roomTypeId) =>
        _roomTypes.FirstOrDefault(r => r.Id == roomTypeId)
        ?? throw new DomainException("RoomType not found in this hotel.");
}
