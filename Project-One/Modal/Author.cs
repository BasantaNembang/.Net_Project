
using Microsoft.EntityFrameworkCore;

namespace Project_One.Modal
{
    [Index(nameof(Name), IsUnique = true)]
    public class Author
    {
        public int Id { get; set; }


        //we set Name as unique but in real life we can use author-email as identifier
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

        public ICollection<Book> Book { get; set; } = new List<Book>();

    }
}



