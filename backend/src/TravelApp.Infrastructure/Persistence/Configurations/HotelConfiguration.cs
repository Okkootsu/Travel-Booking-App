using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelApp.Domain.Entities;

namespace TravelApp.Infrastructure.Persistence.Configurations;

public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
{
    public void Configure(EntityTypeBuilder<Hotel> builder)
    {
        builder.ToTable("Hotels");

        builder.HasKey(h => h.Id);
        builder.Ignore(h => h.DomainEvents);

        builder.Property(h => h.DestinationId)
            .IsRequired();

        builder.Property(h => h.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(h => h.Slug)
            .IsRequired()
            .HasMaxLength(220);

        builder.Property(h => h.Description)
            .IsRequired()
            .HasMaxLength(4000);

        builder.Property(h => h.PropertyType)
            .IsRequired();

        builder.Property(h => h.StarRating)
            .IsRequired();

        builder.Property(h => h.CheckInTime)
            .IsRequired();

        builder.Property(h => h.CheckOutTime)
            .IsRequired();

        builder.Property(h => h.Status)
            .IsRequired();

        builder.Property(h => h.AverageRating)
            .HasPrecision(3, 2)
            .IsRequired();

        builder.Property(h => h.ReviewCount)
            .IsRequired();

        builder.OwnsOne(h => h.Address, addr =>
        {
            addr.Property(a => a.Country)
                .HasColumnName("AddressCountry")
                .IsRequired()
                .HasMaxLength(100);

            addr.Property(a => a.City)
                .HasColumnName("AddressCity")
                .IsRequired()
                .HasMaxLength(100);

            addr.Property(a => a.District)
                .HasColumnName("AddressDistrict")
                .HasMaxLength(100);

            addr.Property(a => a.Street)
                .HasColumnName("AddressStreet")
                .IsRequired()
                .HasMaxLength(250);

            addr.Property(a => a.PostalCode)
                .HasColumnName("AddressPostalCode")
                .HasMaxLength(20);
        });

        builder.OwnsOne(h => h.Location, loc =>
        {
            loc.Property(l => l.Latitude)
                .HasColumnName("Latitude")
                .IsRequired();

            loc.Property(l => l.Longitude)
                .HasColumnName("Longitude")
                .IsRequired();
        });

        builder.HasOne<Destination>()
            .WithMany()
            .HasForeignKey(h => h.DestinationId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(h => h.RoomTypes)
            .WithOne()
            .HasForeignKey(r => r.HotelId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Navigation(h => h.RoomTypes)
            .UsePropertyAccessMode(PropertyAccessMode.Field);

        builder.HasMany(h => h.Images)
            .WithOne()
            .HasForeignKey(i => i.HotelId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Navigation(h => h.Images)
            .UsePropertyAccessMode(PropertyAccessMode.Field);

        builder.HasMany(h => h.HotelAmenities)
            .WithOne()
            .HasForeignKey(ha => ha.HotelId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Navigation(h => h.HotelAmenities)
            .UsePropertyAccessMode(PropertyAccessMode.Field);

        builder.HasIndex(h => h.Slug)
            .IsUnique();

        builder.HasIndex(h => new { h.DestinationId, h.Status, h.StarRating });
        builder.HasIndex(h => new { h.Status, h.PropertyType });
    }
}
