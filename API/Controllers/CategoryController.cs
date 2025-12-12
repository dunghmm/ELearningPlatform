using ELearningPlatform.API.Models.DtoModels.Category;
using ELearningPlatform.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ELearningPlatform.API.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDto dto)
        {
            var response = await _categoryService.Create(dto);
            return BaseResult(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var response = await _categoryService.GetList();
            return BaseResult(response);
        }
    }
}
