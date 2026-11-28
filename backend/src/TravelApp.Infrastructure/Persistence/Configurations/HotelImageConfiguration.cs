using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelApp.Domain.Entities;

namespace TravelApp.Infrastructure.Persistence.Configurations;

public class HotelImageConfiguration : IEntityTypeConfiguration<HotelImage>
{
    public void Configure(EntityTypeBuilder<HotelImage> builder)
    {
        builder.ToTable("HotelImages");

        builder.HasKey(i => i.Id);

        builder.Property(i => i.HotelId)
            .IsRequired();

        builder.Property(i => i.RoomTypeId);

        builder.Property(i => i.Url)
            .IsRequired()
            .HasMaxLength(1000);

        builder.Property(i => i.AltText)
            .IsRequired()
            .HasMaxLength(250);

        builder.Property(i => i.SortOrder)
            .IsRequired();

        builder.Property(i => i.IsPrimary)
            .IsRequired();

        builder.HasOne<RoomType>()
            .WithMany()
            .HasForeignKey(i => i.RoomTypeId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasIndex(i => new { i.HotelId, i.SortOrder });

        builder.HasIndex(i => i.HotelId)
            .IsUnique()
            .HasFilter("\"IsPrimary\" = true");
    }
}
