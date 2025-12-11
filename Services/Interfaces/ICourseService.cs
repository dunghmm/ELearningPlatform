using ELearningPlatform.Models.CommonModels;
using ELearningPlatform.Models.DtoModels.Course;

namespace ELearningPlatform.Services.Interfaces
{
    public interface ICourseService
    {
        Task<ApiResponse> Create(CreateCourseDto dto);

        Task<ApiResponse> GetList();
    }
}
