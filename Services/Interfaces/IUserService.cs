using ELearningPlatform.Models.CommonModels;

using ELearningPlatform.Models.DtoModels.User;
using ELearningPlatform.Models.DtoModels.Auth;

namespace ELearningPlatform.Services.Interfaces
{
    public interface IUserService
    {
        Task<ApiResponse> RegisterAsync(RegisterRequestDto dto);
        Task<ApiResponse> GetUserInfoAsync(int userId);


    }
}




