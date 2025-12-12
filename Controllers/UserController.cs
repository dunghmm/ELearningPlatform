using ELearningPlatform.Controllers;
using ELearningPlatform.Models.DtoModels.Auth;
using ELearningPlatform.Models.DtoModels.User;
using ELearningPlatform.Services.Implements;
using ELearningPlatform.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;




namespace ELearningPlatform.Controllers
{
    [Route("v1/user")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// API get user info
        /// </summary>
        [Authorize]
        [HttpGet("me")]
        public async Task<IActionResult> GetUserInfoAsync()
        {
            // Lấy userId từ token
            var userIdString = User.FindFirst("UserId")?.Value;

            if (string.IsNullOrEmpty(userIdString))
                return Unauthorized(new { message = "Token không hợp lệ hoặc không chứa UserId" });

            int userId = int.Parse(userIdString);

            var data = await _userService.GetUserInfoAsync(userId);
     
            return BaseResult(data);
        }

        /// <summary>
        /// API update user info
        /// </summary>
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto dto)
        {
            var result = await _userService.RegisterAsync(dto);
            return Ok(result);
        }
    }
}



