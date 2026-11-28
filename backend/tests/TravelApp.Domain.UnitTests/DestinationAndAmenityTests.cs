using TravelApp.Domain.Entities;
using TravelApp.Domain.Enums;
using TravelApp.Domain.Exceptions;
using TravelApp.Domain.ValueObjects;

namespace TravelApp.Domain.UnitTests;

public class DestinationAndAmenityTests
{
    [Fact]
    public void Destination_Create_ShouldNormalizeSlugAndCountryCode()
    {
        var destination = new Destination(
            " Istanbul ",
            " Turkey ",
            "tr",
            " ISTANBUL ",
            GeoLocation.Create(41.0082, 28.9784),
            " Historic city ",
            isFeatured: true);

        Assert.Equal("Istanbul", destination.Name);
        Assert.Equal("Turkey", destination.Country);
        Assert.Equal("TR", destination.CountryCode);
        Assert.Equal("istanbul", destination.Slug);
        Assert.True(destination.IsFeatured);
    }

    [Fact]
    public void Destination_Create_WithInvalidCountryCode_ShouldThrow()
    {
        Assert.Throws<DomainException>(() =>
            new Destination("Rome", "Italy", "ITA", "rome", GeoLocation.Create(41.9, 12.5)));
    }

    [Fact]
    public void Amenity_Create_ShouldNormalizeCodeAndIconKey()
    {
        var amenity = new Amenity(
            " FREE_WIFI ",
            " Free Wi-Fi ",
            AmenityCategory.General,
            AmenityScope.Both,
            " WIFI ");

        Assert.Equal("free_wifi", amenity.Code);
        Assert.Equal("Free Wi-Fi", amenity.Name);
        Assert.Equal("wifi", amenity.IconKey);
    }

    [Fact]
    public void Amenity_Create_WithMissingCode_ShouldThrow()
    {
        Assert.Throws<DomainException>(() =>
            new Amenity(" ", "Free Wi-Fi", AmenityCategory.General, AmenityScope.Both, "wifi"));
    }
}
