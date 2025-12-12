using BCrypt.Net;
using ELearningPlatform.Models.CommonModels;
using ELearningPlatform.Models.DtoModels.Auth;
using ELearningPlatform.Models.DtoModels.User;
using ELearningPlatform.Models.EntityModels;
using ELearningPlatform.Repository.Interfaces;
using ELearningPlatform.Services.Interfaces;
using System.Security.Claims;

namespace ELearningPlatform.Services.Implements
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ApiResponse> GetUserInfoAsync(int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null || user.DeleteFlag)
                return ApiResponse.Response(DefineResponse.EnumCodes.R_CMN_404_01);

            var dto = new UserInfoDto
            {
                UserName = user.Username,
                Email = user.Email,
                Role = user.Role
            };

            return ApiResponse.Response(DefineResponse.EnumCodes.R_CMN_200_01, dto);
        }

        public async Task<ApiResponse> GetUserInfoAsync()
        {
            var userIdStr = _httpContextAccessor.HttpContext?
                .User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userIdStr))
                return ApiResponse.Response(DefineResponse.EnumCodes.R_CMN_401_01);

            int userId = int.Parse(userIdStr);

            return await GetUserInfoAsync(userId);
        }


        // register
        public async Task<ApiResponse> RegisterAsync(RegisterRequestDto dto)
        {
            // 1. Kiểm tra username/email đã tồn tại
            if (_userRepository.GetAll().Any(u => u.Username == dto.Username))
            {
                return ApiResponse.Response("Username already exists");
            }

            if (_userRepository.GetAll().Any(u => u.Email == dto.Email))
            {
                return ApiResponse.Response("Email already exists");
            }

            // 2. Hash password
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            // 3. Tạo entity user
            var user = new User
            {
                Username = dto.Username,
                Email = dto.Email,
                PasswordHash = passwordHash,
                Role = "user",  
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                DeleteFlag = false
            };

            // 4. Lưu vào DB
            await _userRepository.CreateAsync(user);
            await _userRepository.SaveChangesAsync();

            return ApiResponse.Response("User registered successfully");
        }

      
    }
}







