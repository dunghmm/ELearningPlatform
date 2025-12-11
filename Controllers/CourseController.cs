using ELearningPlatform.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ELearningPlatform.Controllers
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
        public async Task<IActionResult> Create(string title)
        {
            var response = await _courseService.Create(title);
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
