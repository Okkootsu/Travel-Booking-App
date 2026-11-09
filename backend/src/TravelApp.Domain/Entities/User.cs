using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelApp.Domain.Common;
using TravelApp.Domain.Enums;

namespace TravelApp.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Email { get; private set; } = null!;
        public string PasswordHash { get; private set; } = null!;
        public UserRole Role { get; private set; }
        public string? RefreshToken { get; private set; }
        public DateTime? RefreshTokenExpiryTimeUtc { get; private set; }

        private User() { }

        public User(string email, string passwordHash, UserRole role = UserRole.User)
        {
            Email = email;
            PasswordHash = passwordHash;
            Role = role;
        }

        public void SetRefreshToken(string refreshToken, DateTime expiryTimeUtc)
        {
            RefreshToken = refreshToken;
            RefreshTokenExpiryTimeUtc = expiryTimeUtc;
            UpdatedAtUtc = DateTime.UtcNow;
        }

        public void RevokeRefreshToken()
        {
            RefreshToken = null;
            RefreshTokenExpiryTimeUtc = null;
            UpdatedAtUtc = DateTime.UtcNow;
        }

        public void UpdatePassword(string newPasswordHash)
        {
            PasswordHash = newPasswordHash;
            UpdatedAtUtc = DateTime.UtcNow;
        }
    }
}