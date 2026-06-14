namespace Project_One.DTO
{
    public class AuthorDTO
    {

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

        public ICollection<BookDTO> Book { get; set; } = new List<BookDTO>();


    }
}
