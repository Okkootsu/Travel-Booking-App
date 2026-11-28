using TravelApp.Domain.Exceptions;

namespace TravelApp.Domain.Entities;

public class HotelAmenity
{
    public Guid HotelId { get; private set; }
    public Guid AmenityId { get; private set; }

    private HotelAmenity() { }

    internal HotelAmenity(Guid hotelId, Guid amenityId)
    {
        if (hotelId == Guid.Empty)
            throw new DomainException("HotelId is required.");

        if (amenityId == Guid.Empty)
            throw new DomainException("AmenityId is required.");

        HotelId = hotelId;
        AmenityId = amenityId;
    }
}
