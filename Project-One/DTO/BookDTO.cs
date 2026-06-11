using System.ComponentModel.DataAnnotations;

namespace Project_One.DTO
{
    public class BookDTO{

        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Desc { get; set; } = string.Empty;
    }
}
