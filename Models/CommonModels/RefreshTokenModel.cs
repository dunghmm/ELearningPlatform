namespace ELearningPlatform.Models.Common
{
    public class RefreshTokenModel
    {
        public string RawToken { get; set; }
        public string TokenHash { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}
