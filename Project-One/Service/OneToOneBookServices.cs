//using Microsoft.EntityFrameworkCore;
//using Project_One.Data;
//using Project_One.DTO;
//using Project_One.Modal;
//using Project_One.Service.Interfaces;

//namespace Project_One.Service
//{
//    public class OneToOneBookServices : IOneToOneBookService
//    {

//        private readonly AppDbContext dbContext;
//        private readonly ILogger<OneToOneBookServices> logger;

//        public OneToOneBookServices(AppDbContext dbContext,
//            ILogger<OneToOneBookServices> logger)
//        {
//            this.dbContext = dbContext;
//            this.logger = logger;
//        }



//        public async Task<BookMDTO> CreateBook(BookMDTO book)
//        {

//            var bookDetials = new BookDetails
//            {
//                AuthorName = book.AuthorName,
//                Price = book.Price,
//                Book = new Book
//                {
//                    Name = book.Book.Name,
//                    Title = book.Book.Title,
//                    Desc = book.Book.Desc
//                }
//            };

//            dbContext.BookDetails.Add(bookDetials);
//            await dbContext.SaveChangesAsync();


//            return book;
//        }





//        public async Task<List<BookMDTO>> GetAllDataAsync()
//        {
//           return await dbContext.BookDetails
//                .Select(d => new BookMDTO
//                {
//                    Id = d.Id,
//                    AuthorName = d.AuthorName,
//                    Price = d.Price,
//                    Book = d.Book == null ? null : new BookDTO()
//                    {
//                        Id = d.Book.Id,
//                        Name = d.Book.Name,
//                        Title = d.Book.Title,
//                        Desc = d.Book.Desc
//                    }
//                })
//                .ToListAsync();

//        }
//    }
//}


