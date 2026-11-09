using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelApp.Application.Features.Auth
{
    public record AuthResponse(
        Guid UserId,
        string Email,
        string Role,
        string AccessToken,
        string RefreshToken,
        DateTime AccessTokenExpirationUtc
    );
}