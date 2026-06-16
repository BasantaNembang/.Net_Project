using System.ComponentModel.DataAnnotations;

namespace Auth_Project.DTO
{
    public class UserDto
    {
        [Required]
        public string Username { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
    }
}


