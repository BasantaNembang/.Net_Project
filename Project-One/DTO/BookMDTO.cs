using System.ComponentModel.DataAnnotations;

namespace Project_One.DTO
{
    //used for one to one relationship(BookDetails) with book
    public class BookMDTO { //BookDetails

        public int Id { get; set; }
        public int Price { get; set; }

        [Required]
        public string AuthorName { get; set; } = string.Empty;

 
        public BookDTO? Book { get; set; }
    
    }
}


