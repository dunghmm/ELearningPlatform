using ELearningPlatform.API.Models.CommonModels;
using ELearningPlatform.API.Models.DtoModels.Auth;
using ELearningPlatform.API.Models.EntityModels;
using ELearningPlatform.API.Repository.Interfaces;
using ELearningPlatform.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ELearningPlatform.API.Services.Implements
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailService _emailService;
        public AuthService(IUserRepository userRepository, IUnitOfWork unitOfWork, IEmailService emailService)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _emailService = emailService;
        }
        public Task<ApiResponse> LoginAsync(LoginRequestDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> LogoutAsync(LogoutRequestDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse> RegisterAsync(RegisterRequestDto dto)
        {
            var user = await _userRepository.FindByCondition(u => u.Username == dto.Username).FirstOrDefaultAsync();
            if (user != null)
            {
                return ApiResponse.Response(DefineResponse.EnumCodes.R_CMN_400_01);
            }
            var newUser = new User {
                Username = dto.Username,
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Role = "User"

            };
            await _userRepository.CreateAsync(newUser);
            await _unitOfWork.CommitAsync();
            await _emailService.SendEmailAsync(newUser.Email, "Welcome to ELearning Platform", "Thank you for registering!");
            return ApiResponse.Response(DefineResponse.EnumCodes.R_CMN_200_01);
        }
    }
}
