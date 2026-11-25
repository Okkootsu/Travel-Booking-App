using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace TravelApp.Application.Features.Auth.Commands.Register
{
    public record RegisterCommand(
        string Email,
        string Password
    ) : IRequest<AuthResponse>;
}