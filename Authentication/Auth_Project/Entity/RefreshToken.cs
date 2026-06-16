
namespace Auth_Project.Entity
{
    public class RefreshToken
    {
        public Guid Id { get; set; }

        public DateTime ExpiryTime { get; set; }
        public string Token { get; set; } = null!;


        public int UserId { get; set; }

        public User? User { get; set; }

    }
}










