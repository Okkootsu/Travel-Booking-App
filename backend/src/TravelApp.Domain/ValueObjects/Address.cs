using TravelApp.Domain.Exceptions;

namespace TravelApp.Domain.ValueObjects;

public sealed record Address
{
    public string Country { get; private set; } = null!;
    public string City { get; private set; } = null!;
    public string? District { get; private set; }
    public string Street { get; private set; } = null!;
    public string? PostalCode { get; private set; }

    private Address() { }

    private Address(string country, string city, string? district, string street, string? postalCode)
    {
        Country = country;
        City = city;
        District = district;
        Street = street;
        PostalCode = postalCode;
    }

    public static Address Create(
        string country,
        string city,
        string street,
        string? district = null,
        string? postalCode = null)
    {
        if (string.IsNullOrWhiteSpace(country))
            throw new DomainException("Address country is required.");

        if (string.IsNullOrWhiteSpace(city))
            throw new DomainException("Address city is required.");

        if (string.IsNullOrWhiteSpace(street))
            throw new DomainException("Address street is required.");

        return new Address(
            country.Trim(),
            city.Trim(),
            string.IsNullOrWhiteSpace(district) ? null : district.Trim(),
            street.Trim(),
            string.IsNullOrWhiteSpace(postalCode) ? null : postalCode.Trim());
    }
}
