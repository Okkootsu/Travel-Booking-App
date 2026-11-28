using TravelApp.Domain.Enums;
using TravelApp.Domain.Exceptions;
using TravelApp.Domain.ValueObjects;

namespace TravelApp.Domain.UnitTests;

public class ValueObjectsTests
{
    [Fact]
    public void Address_Create_ShouldTrimFieldsAndAllowOptionalFields()
    {
        var address = Address.Create(" Turkey ", " Istanbul ", " Istiklal Cad. No 10 ", " Beyoglu ", " 34430 ");

        Assert.Equal("Turkey", address.Country);
        Assert.Equal("Istanbul", address.City);
        Assert.Equal("Istiklal Cad. No 10", address.Street);
        Assert.Equal("Beyoglu", address.District);
        Assert.Equal("34430", address.PostalCode);
    }

    [Theory]
    [InlineData("", "Istanbul", "Street")]
    [InlineData("Turkey", " ", "Street")]
    [InlineData("Turkey", "Istanbul", "")]
    public void Address_Create_WithMissingRequiredFields_ShouldThrow(string country, string city, string street)
    {
        Assert.Throws<DomainException>(() => Address.Create(country, city, street));
    }

    [Theory]
    [InlineData(-90.1, 0)]
    [InlineData(90.1, 0)]
    [InlineData(0, -180.1)]
    [InlineData(0, 180.1)]
    public void GeoLocation_Create_OutOfRange_ShouldThrow(double lat, double lon)
    {
        Assert.Throws<DomainException>(() => GeoLocation.Create(lat, lon));
    }

    [Fact]
    public void Money_CreateAndOperations_ShouldRoundNormalizeCurrencyAndRejectMismatch()
    {
        var a = Money.Create(100.125m, "usd");
        var b = Money.Create(25.10m, "USD");
        var eur = Money.Create(10m, "EUR");

        Assert.Equal("USD", a.Currency);
        Assert.Equal(100.13m, a.Amount);
        Assert.Equal(125.23m, a.Add(b).Amount);
        Assert.Equal(200.26m, a.Multiply(2m).Amount);

        Assert.Throws<DomainException>(() => a.Add(eur));
        Assert.Throws<DomainException>(() => Money.Create(-1m, "USD"));
        Assert.Throws<DomainException>(() => Money.Create(10m, "US"));
    }

    [Fact]
    public void DateRange_Create_ShouldComputeNightsAndRejectInvalidRange()
    {
        var range = DateRange.Create(new DateOnly(2026, 12, 10), new DateOnly(2026, 12, 14));
        Assert.Equal(4, range.Nights);

        Assert.Throws<DomainException>(() =>
            DateRange.Create(new DateOnly(2026, 12, 10), new DateOnly(2026, 12, 10)));
        Assert.Throws<DomainException>(() =>
            DateRange.Create(new DateOnly(2026, 12, 12), new DateOnly(2026, 12, 10)));
    }

    [Fact]
    public void Occupancy_CanAccommodate_ShouldEnforceGuestBounds()
    {
        var occupancy = Occupancy.Create(maxAdults: 2, maxChildren: 2, maxTotalGuests: 3);

        Assert.True(occupancy.CanAccommodate(2, 1));
        Assert.True(occupancy.CanAccommodate(1, 2));
        Assert.False(occupancy.CanAccommodate(2, 2));
        Assert.False(occupancy.CanAccommodate(3, 0));
        Assert.False(occupancy.CanAccommodate(0, 1));
        Assert.False(occupancy.CanAccommodate(1, -1));

        Assert.Throws<DomainException>(() => Occupancy.Create(0, 1, 1));
        Assert.Throws<DomainException>(() => Occupancy.Create(2, 1, 1));
        Assert.Throws<DomainException>(() => Occupancy.Create(2, 1, 4));
    }

    [Fact]
    public void CancellationPolicy_Factories_ShouldEnforceInvariants()
    {
        var free = CancellationPolicy.FreeCancellation(3);
        Assert.Equal(CancellationType.FreeCancellation, free.Type);
        Assert.Equal(3, free.FreeCancellationDaysBeforeCheckIn);
        Assert.Equal(0m, free.PenaltyPercentage);

        var partial = CancellationPolicy.PartialRefund(50m);
        Assert.Equal(CancellationType.PartialRefund, partial.Type);
        Assert.Equal(50m, partial.PenaltyPercentage);

        var nonRefundable = CancellationPolicy.NonRefundable();
        Assert.Equal(CancellationType.NonRefundable, nonRefundable.Type);
        Assert.Equal(100m, nonRefundable.PenaltyPercentage);

        Assert.Throws<DomainException>(() => CancellationPolicy.FreeCancellation(-1));
        Assert.Throws<DomainException>(() => CancellationPolicy.PartialRefund(0m));
        Assert.Throws<DomainException>(() => CancellationPolicy.PartialRefund(100m));
    }
}
