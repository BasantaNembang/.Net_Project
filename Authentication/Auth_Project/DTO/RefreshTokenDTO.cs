
namespace Auth_Project.DTO
{
    public class RefreshTokenDTO
    {
        public DateTime ExpiryTime { get; set; }
        public string Token { get; set; } = null!;

        public int UserId { get; set; }
    }
}
