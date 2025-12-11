using ELearningPlatform.Models.CommonModels;
using ELearningPlatform.Models.DtoModels.Auth;

namespace ELearningPlatform.Services.Interfaces
{
    public interface IAuthService
    {
        Task<ApiResponse> LoginAsync(LoginRequestDto dto);

        Task<ApiResponse> LogoutAsync(LogoutRequestDto dto);

        Task<ApiResponse> RegisterAsync(RegisterRequestDto dto);
    }
}
