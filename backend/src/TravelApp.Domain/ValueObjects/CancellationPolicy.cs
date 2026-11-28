using TravelApp.Domain.Enums;
using TravelApp.Domain.Exceptions;

namespace TravelApp.Domain.ValueObjects;

public sealed record CancellationPolicy
{
    public CancellationType Type { get; private set; }
    public int? FreeCancellationDaysBeforeCheckIn { get; private set; }
    public decimal? PenaltyPercentage { get; private set; }

    private CancellationPolicy() { }

    private CancellationPolicy(
        CancellationType type,
        int? freeCancellationDaysBeforeCheckIn,
        decimal? penaltyPercentage)
    {
        Type = type;
        FreeCancellationDaysBeforeCheckIn = freeCancellationDaysBeforeCheckIn;
        PenaltyPercentage = penaltyPercentage;
    }

    public static CancellationPolicy FreeCancellation(int daysBeforeCheckIn)
    {
        if (daysBeforeCheckIn < 0)
            throw new DomainException("FreeCancellationDaysBeforeCheckIn cannot be negative.");

        return new CancellationPolicy(CancellationType.FreeCancellation, daysBeforeCheckIn, 0m);
    }

    public static CancellationPolicy PartialRefund(decimal penaltyPercentage)
    {
        if (penaltyPercentage is <= 0 or >= 100)
            throw new DomainException("PenaltyPercentage for partial refund must be between 0 and 100 (exclusive).");

        return new CancellationPolicy(CancellationType.PartialRefund, null, penaltyPercentage);
    }

    public static CancellationPolicy NonRefundable() =>
        new(CancellationType.NonRefundable, null, 100m);
}
