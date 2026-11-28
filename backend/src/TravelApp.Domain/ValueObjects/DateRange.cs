using TravelApp.Domain.Exceptions;

namespace TravelApp.Domain.ValueObjects;

public sealed record DateRange
{
    public DateOnly CheckIn { get; private set; }
    public DateOnly CheckOut { get; private set; }
    public int Nights => CheckOut.DayNumber - CheckIn.DayNumber;

    private DateRange() { }

    private DateRange(DateOnly checkIn, DateOnly checkOut)
    {
        CheckIn = checkIn;
        CheckOut = checkOut;
    }

    public static DateRange Create(DateOnly checkIn, DateOnly checkOut)
    {
        if (checkOut <= checkIn)
            throw new DomainException("Check-out date must be after check-in date.");

        return new DateRange(checkIn, checkOut);
    }
}
