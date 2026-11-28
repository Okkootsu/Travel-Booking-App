using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelApp.Domain.Entities;

namespace TravelApp.Infrastructure.Persistence.Configurations;

public class RoomTypeConfiguration : IEntityTypeConfiguration<RoomType>
{
    public void Configure(EntityTypeBuilder<RoomType> builder)
    {
        builder.ToTable("RoomTypes");

        builder.HasKey(r => r.Id);

        builder.Property(r => r.HotelId)
            .IsRequired();

        builder.Property(r => r.Name)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(r => r.Description)
            .IsRequired()
            .HasMaxLength(2000);

        builder.Property(r => r.BedConfiguration)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(r => r.SizeSqm);

        builder.Property(r => r.TotalRoomCount)
            .IsRequired();

        builder.Property(r => r.IsActive)
            .IsRequired();

        builder.OwnsOne(r => r.Occupancy, occ =>
        {
            occ.Property(o => o.MaxAdults)
                .HasColumnName("MaxAdults")
                .IsRequired();

            occ.Property(o => o.MaxChildren)
                .HasColumnName("MaxChildren")
                .IsRequired();

            occ.Property(o => o.MaxTotalGuests)
                .HasColumnName("MaxTotalGuests")
                .IsRequired();

            occ.HasIndex(o => new { o.MaxAdults, o.MaxTotalGuests });
        });

        builder.OwnsOne(r => r.BaseNightlyPrice, money =>
        {
            money.Property(m => m.Amount)
                .HasColumnName("BaseNightlyPriceAmount")
                .HasPrecision(18, 2)
                .IsRequired();

            money.Property(m => m.Currency)
                .HasColumnName("BaseNightlyPriceCurrency")
                .HasMaxLength(3)
                .IsRequired();
        });

        builder.HasMany(r => r.RoomTypeAmenities)
            .WithOne()
            .HasForeignKey(ra => ra.RoomTypeId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Navigation(r => r.RoomTypeAmenities)
            .UsePropertyAccessMode(PropertyAccessMode.Field);

        builder.HasIndex(r => new { r.HotelId, r.Name })
            .IsUnique();

        builder.HasIndex(r => new { r.HotelId, r.IsActive });
    }
}
