using ELearningPlatform.Models.CommonModels;
using ELearningPlatform.Models.DtoModels.Category;


namespace ELearningPlatform.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<ApiResponse> Create(CreateCategoryDto dto);

        Task<ApiResponse> GetList();
    }
}
