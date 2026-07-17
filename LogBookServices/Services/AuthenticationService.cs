using LogBookServices.DTOs;
using LogBookServices.Interfaces;
using Microsoft.Extensions.Configuration;

namespace LogBookServices.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IConfiguration _configuration;

        public AuthenticationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task<AuthResponseDto?> LoginAsync(LoginRequestDto request)
        {
            if (request.Username != "admin" || request.Password != "admin")
                return Task.FromResult<AuthResponseDto?>(null);

            var response = new AuthResponseDto
            {
                Token = "some_jwt_token",
                Expiration = DateTime.UtcNow.AddHours(1)
            };

            return Task.FromResult<AuthResponseDto?>(response);
        }
    }
}