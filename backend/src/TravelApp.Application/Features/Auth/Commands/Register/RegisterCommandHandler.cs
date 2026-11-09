using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using TravelApp.Application.Common.Interfaces;
using TravelApp.Domain.Entities;
using TravelApp.Domain.Enums;

namespace TravelApp.Application.Features.Auth.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterCommandHandler(
            IUserRepository userRepository,
            IPasswordHasher passwordHasher,
            IJwtTokenGenerator jwtTokenGenerator,
            IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _jwtTokenGenerator = jwtTokenGenerator;
            _unitOfWork = unitOfWork;
        }
        
        public async Task<AuthResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var normalizedEmail = request.Email.Trim().ToLowerInvariant();
            var emailExists = await _userRepository.IsExistsByEmailAsync(normalizedEmail, cancellationToken);
            if (emailExists)
            {
                throw new InvalidOperationException("This e-mail already in use.");
            }

            var passwordHash = _passwordHasher.HashPassword(request.Password);
            var user = new User(
                normalizedEmail,
                passwordHash,
                UserRole.User
            );

            var accessToken = _jwtTokenGenerator.GenerateAccessToken(user);
            var refreshToken = _jwtTokenGenerator.GenerateRefreshToken();
            var refreshTokenExpiresUtc = DateTime.UtcNow.AddDays(7);
            
            user.SetRefreshToken(refreshToken, refreshTokenExpiresUtc);

            await _userRepository.AddAsync(user, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new AuthResponse(
                user.Id,
                user.Email,
                user.Role.ToString(),
                accessToken,
                refreshToken,
                refreshTokenExpiresUtc
            );
        }
    }
}