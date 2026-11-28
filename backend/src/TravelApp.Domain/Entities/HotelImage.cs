using TravelApp.Domain.Common;
using TravelApp.Domain.Exceptions;

namespace TravelApp.Domain.Entities;

public class HotelImage : BaseEntity
{
    public Guid HotelId { get; private set; }
    public Guid? RoomTypeId { get; private set; }
    public string Url { get; private set; } = null!;
    public string AltText { get; private set; } = null!;
    public int SortOrder { get; private set; }
    public bool IsPrimary { get; private set; }

    private HotelImage() { }

    internal HotelImage(
        Guid hotelId,
        string url,
        string altText,
        int sortOrder,
        bool isPrimary,
        Guid? roomTypeId = null)
    {
        if (hotelId == Guid.Empty)
            throw new DomainException("HotelId is required.");

        if (string.IsNullOrWhiteSpace(url))
            throw new DomainException("Image URL is required.");

        if (string.IsNullOrWhiteSpace(altText))
            throw new DomainException("Image alt text is required.");

        if (sortOrder < 0)
            throw new DomainException("SortOrder cannot be negative.");

        HotelId = hotelId;
        RoomTypeId = roomTypeId;
        Url = url.Trim();
        AltText = altText.Trim();
        SortOrder = sortOrder;
        IsPrimary = isPrimary;
    }

    internal void SetPrimary(bool isPrimary)
    {
        IsPrimary = isPrimary;
        UpdatedAtUtc = DateTime.UtcNow;
    }

    internal void UpdateDetails(string altText, int sortOrder)
    {
        if (string.IsNullOrWhiteSpace(altText))
            throw new DomainException("Image alt text is required.");

        if (sortOrder < 0)
            throw new DomainException("SortOrder cannot be negative.");

        AltText = altText.Trim();
        SortOrder = sortOrder;
        UpdatedAtUtc = DateTime.UtcNow;
    }
}
