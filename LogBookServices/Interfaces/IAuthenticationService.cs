using LogBookServices.DTOs;

namespace LogBookServices.Interfaces
{
    public interface IAuthenticationService
    {
        Task<AuthResponseDto?> Authenticate(LoginRequestDto request);
    }
}
