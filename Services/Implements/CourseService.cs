using ELearningPlatform.Models.CommonModels;
using ELearningPlatform.Models.EntityModels;
using ELearningPlatform.Repository.Interfaces;
using ELearningPlatform.Services.Interfaces;

namespace ELearningPlatform.Services.Implements
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public async Task<ApiResponse> Create(string title)
        {
            var course = new Course { Title = title };
            await _courseRepository.CreateAsync(course);
            await _courseRepository.SaveChangesAsync();
            return ApiResponse.Response(DefineResponse.EnumCodes.R_CMN_200_01, data: course.Id);

        }

        public async Task<ApiResponse> GetList()
        {
            var courses = await _courseRepository.GetAllAsync();
            return ApiResponse.Response(DefineResponse.EnumCodes.R_CMN_200_01, data: courses);
        }
    }
}
