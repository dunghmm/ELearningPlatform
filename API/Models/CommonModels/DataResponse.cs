namespace ELearningPlatform.API.Models.CommonModels
{
    public class DataResponse
    {
        public int Status { get; set; }
        public required string Code { get; set; }
        public string? field { get; set; } = null;
        public string? value { get; set; } = null;
        public object? Data { get; set; } = null;
    }
}
