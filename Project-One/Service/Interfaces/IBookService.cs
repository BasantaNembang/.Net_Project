using Project_One.DTO;

namespace Project_One.Service.Interfaces
{
    public interface IBookService
    {

        Task<BookDTO> CreateBook(BookDTO bookDTO);
        Task<List<BookDTO>> GetAllBooksAsync();
    }
}
