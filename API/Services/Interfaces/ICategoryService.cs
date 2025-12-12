using ELearningPlatform.API.Models.CommonModels;
using ELearningPlatform.API.Models.DtoModels.Category;

namespace ELearningPlatform.API.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<ApiResponse> Create(CreateCategoryDto dto);

        Task<ApiResponse> GetList();
    }
}
