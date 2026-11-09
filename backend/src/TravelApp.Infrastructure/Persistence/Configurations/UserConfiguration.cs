using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelApp.Domain.Entities;

namespace TravelApp.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(u => u.Id);
            
            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(150);
            
            builder.HasIndex(u => u.Email)
                .IsUnique();
            
            builder.Property(u => u.PasswordHash)
                .IsRequired();
            
            builder.Property(u => u.Role)
                .IsRequired();
            
            builder.Property(u => u.RefreshToken)
                .HasMaxLength(256);
            
            builder.Property(u => u.RefreshTokenExpiryTimeUtc);
        }
    }
}