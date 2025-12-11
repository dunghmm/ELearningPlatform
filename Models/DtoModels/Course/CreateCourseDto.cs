namespace ELearningPlatform.Models.DtoModels.Course
{
    public class CreateCourseDto
    {
        public string Title { get; set; } = null!;

        public string? Subtitle { get; set; }

        public string? Description { get; set; }
    }
}
