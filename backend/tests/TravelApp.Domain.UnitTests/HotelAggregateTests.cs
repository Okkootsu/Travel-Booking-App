using TravelApp.Domain.Entities;
using TravelApp.Domain.Enums;
using TravelApp.Domain.Exceptions;
using TravelApp.Domain.ValueObjects;

namespace TravelApp.Domain.UnitTests;

public class HotelAggregateTests
{
    private static Hotel CreateDraftHotel(int starRating = 5) =>
        new(
            Guid.NewGuid(),
            "Grand Voyago",
            "grand-voyago",
            "Luxury hotel in the city center.",
            PropertyType.Hotel,
            starRating,
            Address.Create("Italy", "Rome", "Via Veneto 1"),
            GeoLocation.Create(41.908, 12.489));

    private static RoomType AddSampleRoom(Hotel hotel, string name = "Deluxe King") =>
        hotel.AddRoomType(
            name,
            "Spacious king bedroom",
            Occupancy.Create(2, 1, 3),
            "1 King Bed",
            Money.Create(220m, "EUR"),
            totalRoomCount: 5,
            sizeSqm: 34);

    [Theory]
    [InlineData(0)]
    [InlineData(6)]
    public void Hotel_Create_WithInvalidStarRating_ShouldThrow(int stars)
    {
        Assert.Throws<DomainException>(() => CreateDraftHotel(stars));
    }

    [Fact]
    public void Hotel_Create_WithEmptyDestinationId_ShouldThrow()
    {
        Assert.Throws<DomainException>(() =>
            new Hotel(
                Guid.Empty,
                "Grand Voyago",
                "grand-voyago",
                "Description",
                PropertyType.Hotel,
                4,
                Address.Create("Italy", "Rome", "Via Veneto 1"),
                GeoLocation.Create(41.908, 12.489)));
    }

    [Fact]
    public void AddRoomType_DuplicateNameCaseInsensitive_ShouldThrow()
    {
        var hotel = CreateDraftHotel();
        AddSampleRoom(hotel, "Deluxe King");

        Assert.Throws<DomainException>(() => AddSampleRoom(hotel, " deluxe king "));
    }

    [Fact]
    public void AddImage_And_SetPrimaryImage_ShouldMaintainSinglePrimaryImage()
    {
        var hotel = CreateDraftHotel();
        var img1 = hotel.AddImage("https://cdn.example.com/1.jpg", "Lobby", 0, isPrimary: true);
        var img2 = hotel.AddImage("https://cdn.example.com/2.jpg", "Pool", 1, isPrimary: true);

        Assert.False(img1.IsPrimary);
        Assert.True(img2.IsPrimary);

        hotel.SetPrimaryImage(img1.Id);
        Assert.True(img1.IsPrimary);
        Assert.False(img2.IsPrimary);
    }

    [Fact]
    public void AddImage_WithForeignRoomTypeId_ShouldThrow()
    {
        var hotel = CreateDraftHotel();

        Assert.Throws<DomainException>(() =>
            hotel.AddImage("https://cdn.example.com/room.jpg", "Room", 0, roomTypeId: Guid.NewGuid()));
    }

    [Fact]
    public void Publish_WithoutActiveRoomOrImage_ShouldThrow()
    {
        var hotel = CreateDraftHotel();
        Assert.Throws<DomainException>(() => hotel.Publish());

        AddSampleRoom(hotel);
        Assert.Throws<DomainException>(() => hotel.Publish());
    }

    [Fact]
    public void Publish_WithRoomAndNonPrimaryImage_ShouldActivateAndPromoteFirstImageToPrimary()
    {
        var hotel = CreateDraftHotel();
        AddSampleRoom(hotel);
        var img2 = hotel.AddImage("https://cdn.example.com/2.jpg", "Second", 2, isPrimary: false);
        var img1 = hotel.AddImage("https://cdn.example.com/1.jpg", "First", 1, isPrimary: false);

        hotel.Publish();

        Assert.Equal(HotelStatus.Active, hotel.Status);
        Assert.True(img1.IsPrimary);
        Assert.False(img2.IsPrimary);
    }

    [Fact]
    public void ActiveHotel_CannotRemoveOrDeactivateLastActiveRoomOrLastImage()
    {
        var hotel = CreateDraftHotel();
        var room = AddSampleRoom(hotel);
        var image = hotel.AddImage("https://cdn.example.com/1.jpg", "Main", 0, isPrimary: true);
        hotel.Publish();

        Assert.Throws<DomainException>(() => hotel.SetRoomTypeActive(room.Id, false));
        Assert.Throws<DomainException>(() => hotel.RemoveRoomType(room.Id));
        Assert.Throws<DomainException>(() => hotel.RemoveImage(image.Id));
    }

    [Fact]
    public void RemovePrimaryImage_WhenOtherImagesExist_ShouldPromoteLowestSortOrderImage()
    {
        var hotel = CreateDraftHotel();
        AddSampleRoom(hotel);
        var primary = hotel.AddImage("https://cdn.example.com/1.jpg", "Main", 0, isPrimary: true);
        var third = hotel.AddImage("https://cdn.example.com/3.jpg", "Third", 5, isPrimary: false);
        var second = hotel.AddImage("https://cdn.example.com/2.jpg", "Second", 2, isPrimary: false);

        hotel.RemoveImage(primary.Id);

        Assert.True(second.IsPrimary);
        Assert.False(third.IsPrimary);
    }

    [Fact]
    public void Amenities_And_RatingSummary_ShouldRespectIdempotencyAndBounds()
    {
        var hotel = CreateDraftHotel();
        var room = AddSampleRoom(hotel);
        var amenityId = Guid.NewGuid();

        hotel.AddAmenity(amenityId);
        hotel.AddAmenity(amenityId);
        Assert.Single(hotel.HotelAmenities);

        hotel.AddRoomTypeAmenity(room.Id, amenityId);
        hotel.AddRoomTypeAmenity(room.Id, amenityId);
        Assert.Single(room.RoomTypeAmenities);

        hotel.UpdateRatingSummary(4.756m, 12);
        Assert.Equal(4.76m, hotel.AverageRating);
        Assert.Equal(12, hotel.ReviewCount);

        Assert.Throws<DomainException>(() => hotel.UpdateRatingSummary(5.1m, 1));
        Assert.Throws<DomainException>(() => hotel.UpdateRatingSummary(4.5m, -1));
    }
}
