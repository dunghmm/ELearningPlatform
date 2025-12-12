using ELearningPlatform.API.Models.DtoModels.Course;
using ELearningPlatform.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ELearningPlatform.API.Controllers
{
    [Route("api/course")]
    [ApiController]
    public class CourseController : BaseController
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCourseDto dto)
        {
            var response = await _courseService.Create(dto);
            return BaseResult(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var response = await _courseService.GetList();
            return BaseResult(response);
        }
    }
}
