using ELearningPlatform.API.Models.CommonModels;
using ELearningPlatform.API.Models.DtoModels.Category;
using ELearningPlatform.API.Models.EntityModels;
using ELearningPlatform.API.Repository.Interfaces;
using ELearningPlatform.API.Services.Interfaces;

namespace ELearningPlatform.API.Services.Implements
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<ApiResponse> Create(CreateCategoryDto dto)
        {
            var category = new Category
            {
                Name = dto.Name,
            };

            await _categoryRepository.CreateAsync(category);
            await _categoryRepository.SaveChangesAsync();
            return ApiResponse.Response(DefineResponse.EnumCodes.R_CMN_200_01, data: category.Id);
        }

        public async Task<ApiResponse> GetList()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return ApiResponse.Response(DefineResponse.EnumCodes.R_CMN_200_01, data: categories);
        }

    }
}
