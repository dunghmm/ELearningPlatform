using System.ComponentModel.DataAnnotations;

namespace ELearningPlatform.Models.DtoModels.Auth
{
    public class RegisterRequestDto
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
        [EmailAddress]
        public required string Email { get; set; }
    }
}
