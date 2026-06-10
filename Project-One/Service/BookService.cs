using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Project_One.Data;
using Project_One.DTO;
using Project_One.Modal;
using Project_One.Service.Interfaces;

namespace Project_One.Service
{
    public class BookService : IBookService{


        private readonly AppDbContext dbContext;

        public BookService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<BookDTO> CreateBook(BookDTO bookDTO)
        {
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



        public async Task<BookDTO> GetBookByIDAsync(int id)
        {
            var data = await dbContext.Books
                .Where(b => b.Id == id)
                .Select(s => new BookDTO{
                    Id = s.Id,
                    Name = s.Name,
                    Title = s.Title,
                    Desc = s.Desc
                }).FirstOrDefaultAsync();

            if (data == null) throw new Exception("No data");

            return data;
        }


        public async Task<string> UpdateTheBodyAysnc(int id, BookDTO book)
        {
            var data = await dbContext.Books.Where(b => b.Id == id).FirstOrDefaultAsync();
            if(data == null) throw new Exception("No data");
            //set the data
            data.Title = book.Title;
            data.Name = book.Name;
            data.Desc = book.Desc;

            await dbContext.SaveChangesAsync();
            return "successfully udated";
        }


        public async Task<string> UpdateTheBodyAysncO(BookDTO book)
        {
            Book b = new Book()
            {
                Id = book.Id,
                Title = book.Title,
                Desc = book.Desc,
                Name = book.Name
            };
            dbContext.Books.Update(b);
            await dbContext.SaveChangesAsync();
            return "successfully udated";
        }


        public async Task<string> DeleteTheDataAsync(int id)
        {
            //ExecuteDeleteAsync can be used to delete all...
            var data = await dbContext.Books.Where(b => b.Id == id).ExecuteDeleteAsync();
            if (data == 0) throw new Exception("No data founded....");
            return "successfully deleted";
        }


    }


}
