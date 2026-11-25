using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using TravelApp.Application.Common.Interfaces;

namespace TravelApp.Application.Features.Auth.Commands.RefreshToken
{
    public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, AuthResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUnitOfWork _unitOfWork;
        
        public RefreshTokenCommandHandler(
            IUserRepository userRepository,
            IJwtTokenGenerator jwtTokenGenerator,
            IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
            _unitOfWork = unitOfWork;
        }

        public async Task<AuthResponse> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByRefreshTokenAsync(request.RefreshToken, cancellationToken);
            if (user == null || user.RefreshTokenExpiryTimeUtc == null || user.RefreshTokenExpiryTimeUtc <= DateTime.UtcNow)
            {
                throw new InvalidOperationException("Invalid or expired refresh token.");
            }

            var newAccessToken = _jwtTokenGenerator.GenerateAccessToken(user);
            var newRefreshToken = _jwtTokenGenerator.GenerateRefreshToken();
            var refreshTokenExpiresUtc = DateTime.UtcNow.AddDays(7);

            user.SetRefreshToken(newRefreshToken, refreshTokenExpiresUtc);

            _userRepository.Update(user);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new AuthResponse(
                user.Id,
                user.Email,
                user.Role.ToString(),
                newAccessToken,
                newRefreshToken,
                refreshTokenExpiresUtc
            );
        }
    }
}