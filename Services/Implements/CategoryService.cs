using ELearningPlatform.Models.CommonModels;
using ELearningPlatform.Models.DtoModels.Category;
using ELearningPlatform.Models.EntityModels;
using ELearningPlatform.Repository.Interfaces;
using ELearningPlatform.Services.Interfaces;

namespace ELearningPlatform.Services.Implements
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
