namespace Thumanya.Shared.Dtos.UserDtos
{
    public class TokenResponseDto
    {
        public string Token { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}
