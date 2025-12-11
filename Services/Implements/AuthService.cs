using ELearningPlatform.Models.CommonModels;
using ELearningPlatform.Models.DtoModels.Auth;
using ELearningPlatform.Services.Interfaces;

namespace ELearningPlatform.Services.Implements
{
    public class AuthService : IAuthService
    {
        public Task<ApiResponse> LoginAsync(LoginRequestDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> LogoutAsync(LogoutRequestDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> RegisterAsync(RegisterRequestDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
