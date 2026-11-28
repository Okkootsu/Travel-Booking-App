using TravelApp.Domain.Exceptions;

namespace TravelApp.Domain.ValueObjects;

public sealed record Occupancy
{
    public int MaxAdults { get; private set; }
    public int MaxChildren { get; private set; }
    public int MaxTotalGuests { get; private set; }

    private Occupancy() { }

    private Occupancy(int maxAdults, int maxChildren, int maxTotalGuests)
    {
        MaxAdults = maxAdults;
        MaxChildren = maxChildren;
        MaxTotalGuests = maxTotalGuests;
    }

    public static Occupancy Create(int maxAdults, int maxChildren, int maxTotalGuests)
    {
        if (maxAdults < 1)
            throw new DomainException("MaxAdults must be at least 1.");

        if (maxChildren < 0)
            throw new DomainException("MaxChildren cannot be negative.");

        if (maxTotalGuests < maxAdults || maxTotalGuests > maxAdults + maxChildren)
            throw new DomainException("MaxTotalGuests must be between MaxAdults and MaxAdults + MaxChildren.");

        return new Occupancy(maxAdults, maxChildren, maxTotalGuests);
    }

    public bool CanAccommodate(int adults, int children)
    {
        if (adults < 1 || children < 0)
            return false;

        return adults <= MaxAdults
            && children <= MaxChildren
            && adults + children <= MaxTotalGuests;
    }
}
