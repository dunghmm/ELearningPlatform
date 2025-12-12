using ELearningPlatform.API.Models.CommonModels;
using ELearningPlatform.API.Models.DtoModels.Auth;

namespace ELearningPlatform.API.Services.Interfaces
{
    public interface IAuthService
    {
        Task<ApiResponse> LoginAsync(LoginRequestDto dto);

        Task<ApiResponse> LogoutAsync(LogoutRequestDto dto);

        Task<ApiResponse> RegisterAsync(RegisterRequestDto dto);
    }
}
