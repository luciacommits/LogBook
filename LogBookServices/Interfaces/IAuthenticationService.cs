using LogBookServices.DTOs;

namespace LogBookServices.Interfaces
{
    public interface IAuthenticationService
    {
        Task<AuthResponseDto?> LoginAsync(LoginRequestDto request);
    }
}
