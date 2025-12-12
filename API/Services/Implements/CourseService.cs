using ELearningPlatform.API.Models.CommonModels;
using ELearningPlatform.API.Models.DtoModels.Course;
using ELearningPlatform.API.Models.EntityModels;
using ELearningPlatform.API.Repository.Interfaces;
using ELearningPlatform.API.Services.Interfaces;

namespace ELearningPlatform.API.Services.Implements
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public async Task<ApiResponse> Create(CreateCourseDto dto)
        {
            var course = new Course { 
                Title = dto.Title,
                Subtitle = dto.Subtitle,
                Description = dto.Description
            };
            
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
