using ELearningPlatform.Models.CommonModels;

namespace ELearningPlatform.Services.Interfaces
{
    public interface ICourseService
    {
        Task<ApiResponse> Create(string name);

        Task<ApiResponse> GetList();
    }
}
