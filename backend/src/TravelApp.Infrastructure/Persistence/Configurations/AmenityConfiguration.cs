using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelApp.Domain.Entities;

namespace TravelApp.Infrastructure.Persistence.Configurations;

public class AmenityConfiguration : IEntityTypeConfiguration<Amenity>
{
    public void Configure(EntityTypeBuilder<Amenity> builder)
    {
        builder.ToTable("Amenities");

        builder.HasKey(a => a.Id);
        builder.Ignore(a => a.DomainEvents);

        builder.Property(a => a.Code)
            .IsRequired()
            .HasMaxLength(80);

        builder.Property(a => a.Name)
            .IsRequired()
            .HasMaxLength(120);

        builder.Property(a => a.Category)
            .IsRequired();

        builder.Property(a => a.Scope)
            .IsRequired();

        builder.Property(a => a.IconKey)
            .IsRequired()
            .HasMaxLength(80);

        builder.HasIndex(a => a.Code)
            .IsUnique();
    }
}
