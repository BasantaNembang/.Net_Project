using Project_One.DTO;

namespace Project_One.Service.Interfaces
{
    public interface IBookService{

        Task<BookDTO> CreateBook(BookDTO bookDTO);
        Task<List<BookDTO>> GetAllBooksAsync();
        Task<BookDTO> GetBookByIDAsync(int id);
        Task<string> UpdateTheBodyAysnc(int id, BookDTO book);
        Task<string> UpdateTheBodyAysncO(BookDTO book);
        Task<string> DeleteTheDataAsync(int id);

    }
}
