using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelApp.Domain.Entities;

namespace TravelApp.Infrastructure.Persistence.Configurations;

public class DestinationConfiguration : IEntityTypeConfiguration<Destination>
{
    public void Configure(EntityTypeBuilder<Destination> builder)
    {
        builder.ToTable("Destinations");

        builder.HasKey(d => d.Id);
        builder.Ignore(d => d.DomainEvents);

        builder.Property(d => d.Name)
            .IsRequired()
            .HasMaxLength(120);

        builder.Property(d => d.Country)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(d => d.CountryCode)
            .IsRequired()
            .HasMaxLength(2);

        builder.Property(d => d.Slug)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(d => d.Description)
            .HasMaxLength(1000);

        builder.Property(d => d.ImageUrl)
            .HasMaxLength(500);

        builder.Property(d => d.IsFeatured)
            .IsRequired();

        builder.OwnsOne(d => d.Location, loc =>
        {
            loc.Property(l => l.Latitude)
                .HasColumnName("Latitude")
                .IsRequired();

            loc.Property(l => l.Longitude)
                .HasColumnName("Longitude")
                .IsRequired();
        });

        builder.HasIndex(d => d.Slug)
            .IsUnique();

        builder.HasIndex(d => d.CountryCode);
        builder.HasIndex(d => d.Name);
    }
}
