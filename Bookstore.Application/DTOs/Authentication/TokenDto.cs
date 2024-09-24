namespace Bookstore.Application.DTOs.Authentication
{
    public class TokenDto
    {
        public string access_token { get; set; } = null!;
        public long expires_in { get; set; }
        public long refresh_expires_in { get; set; }
        public string token_type { get; set; } = null!;
        public string scope { get; set; } = null!;
    }
}
