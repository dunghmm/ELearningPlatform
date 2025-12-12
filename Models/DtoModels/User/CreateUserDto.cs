using System.Runtime.CompilerServices;

namespace ELearningPlatform.Models.DtoModels.User
{
    public class CreateUserDto
    {
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}

