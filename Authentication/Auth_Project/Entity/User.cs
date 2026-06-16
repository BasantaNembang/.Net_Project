using Microsoft.EntityFrameworkCore;

namespace Auth_Project.Entity
{
    [Index(nameof(Username), IsUnique = true)] 
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; } = null!;

        public string PasswordHash { get; set; } = null!;

        public ICollection<RefreshToken> RefreshToken { get; set; } 
            = new HashSet<RefreshToken>();


    }
}




