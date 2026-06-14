using System.ComponentModel.DataAnnotations;

namespace MyApp.Domain.DTO
{
    public class EmployeeDTO
    {

        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Address { get; set; } = string.Empty;

        [Required]
        public string Department { get; set; } = string.Empty;

    }
}
