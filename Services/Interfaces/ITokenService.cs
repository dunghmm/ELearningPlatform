using System.Security.Claims;

namespace ELearningPlatform.Services.Interfaces
{
    public interface ITokenService
    {
        // Tạo Access Token chứa thông tin người dùng
        string GenerateAccessToken(int userId, string username, string role);

        // Tạo Refresh Token dạng random string
        string GenerateRefreshToken();

        // Lấy ClaimsPrincipal từ AccessToken (kể cả token hết hạn)
        ClaimsPrincipal? GetPrincipalFromExpiredToken(string token);
    }
}
