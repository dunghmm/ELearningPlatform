using ELearningPlatform.API.Models.CommonModels;
using ELearningPlatform.API.Models.DtoModels.Course;

namespace ELearningPlatform.API.Services.Interfaces
{
    public interface ICourseService
    {
        Task<ApiResponse> Create(CreateCourseDto dto);

        Task<ApiResponse> GetList();
    }
}
