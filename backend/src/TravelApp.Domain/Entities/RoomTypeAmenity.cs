using TravelApp.Domain.Exceptions;

namespace TravelApp.Domain.Entities;

public class RoomTypeAmenity
{
    public Guid RoomTypeId { get; private set; }
    public Guid AmenityId { get; private set; }

    private RoomTypeAmenity() { }

    internal RoomTypeAmenity(Guid roomTypeId, Guid amenityId)
    {
        if (roomTypeId == Guid.Empty)
            throw new DomainException("RoomTypeId is required.");

        if (amenityId == Guid.Empty)
            throw new DomainException("AmenityId is required.");

        RoomTypeId = roomTypeId;
        AmenityId = amenityId;
    }
}
