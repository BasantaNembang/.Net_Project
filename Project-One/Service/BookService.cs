using Microsoft.EntityFrameworkCore;
using Project_One.Data;
using Project_One.DTO;
using Project_One.Modal;
using Project_One.Service.Interfaces;

namespace Project_One.Service
{
    public class BookService : IBookService{


        private readonly AppDbContext dbContext;

        public BookService(AppDbContext dbContext){
            this.dbContext = dbContext;
        }


        public async Task<BookDTO> CreateBook(BookDTO bookDTO){
            Book book = new Book
            {
                Name = bookDTO.Name,
                Title = bookDTO.Title,
                Desc = bookDTO.Desc
            };
            dbContext.Books.Add(book);
            await dbContext.SaveChangesAsync();
            return bookDTO;
        }



        public async Task<List<BookDTO>> GetAllBooksAsync()
        {
            var data = await dbContext.Books.ToListAsync();
            return data.Select(d => new BookDTO
            {
                Id = d.Id,
                Name = d.Name,
                Title = d.Title,
                Desc = d.Desc
            }).ToList();
        }
    }


}
