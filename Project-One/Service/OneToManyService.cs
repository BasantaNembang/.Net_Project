using Microsoft.EntityFrameworkCore;
using Project_One.Data;
using Project_One.DTO;
using Project_One.Modal;
using Project_One.Service.Interfaces;

namespace Project_One.Service
{
    public class OneToManyService : IOneToMany
    {

        private readonly AppDbContext dbContext;

        public OneToManyService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<AuthorDTO> CreateAuthorAsync(AuthorDTO author)
        {
            Author _author;

            //check wheather the author exist or not
            var existAuthor = dbContext.Authors
                         .FirstOrDefault(x => x.Name == author.Name);


            if (existAuthor != null)  //author already exist-> just add the book to the existing author
            {
                _author = existAuthor;

                foreach(var book in author.Book)
                {
                    _author.Book.Add(new Book()
                    {
                        Title = book.Title,
                        Name = book.Name,
                        Desc = book.Desc
                    });
                }
                //save
                await dbContext.SaveChangesAsync();
                return author;
            }
            else
            {
                Author a = new Author()
                {
                    Name = author.Name,
                    Address = author.Address,
                    Book = author.Book.Select(b => new Book()
                    {
                        Title = b.Title,
                        Name = b.Name,
                        Desc = b.Desc
                    }).ToList()
                };
                await dbContext.Authors.AddAsync(a);
                await dbContext.SaveChangesAsync();

                return author;

            }
        }


        public async Task<List<AuthorDTO>> GetAllAuthorsAsync()
        {
            return await dbContext.Authors
                .Select(a => new AuthorDTO
                {
                    Id = a.Id,
                    Name = a.Name,
                    Address = a.Address,
                    Book = a.Book.Select(b => new BookDTO
                    {
                        Id = b.Id,
                        Name = b.Name,
                        Title = b.Title,
                        Desc = b.Desc
                    }).ToList()
                })
                .ToListAsync();
        }




        public async Task<AuthorDTO> GetAuthorByIDAsync(int id)
        {
           var author = await dbContext.Authors.Where(a => a.Id == id)
                .Select(a => new AuthorDTO
                {
                    Id = a.Id,
                    Name = a.Name,
                    Address = a.Address,
                    Book = a.Book.Select(b => new BookDTO
                    {
                        Id = b.Id,
                        Name = b.Name,
                        Title = b.Title,
                        Desc = b.Desc
                    }).ToList()
                }).FirstOrDefaultAsync();

            if (author == null) throw new Exception("No data");

            return author;
        }




        public async Task<string> UpdateTheBodyAysnc(int id, AuthorDTO authorDTO)
        {
            var author = await dbContext.Authors
                         .Where(a => a.Id == id)
                         .FirstOrDefaultAsync();

            if( author == null) throw new Exception("No Author Found! Can`t be updated");

            //update the body
            author.Name = authorDTO.Name;
            author.Address = authorDTO.Address;

            //update the book
            foreach (var Newbook in authorDTO.Book) //the new book
            {
                //check if already exits or not
                var book = await dbContext.Books.Where(b => b.Id == Newbook.Id)
                                  .FirstOrDefaultAsync();

                if(book != null) //book exits
                {
                    book.Name = Newbook.Name;
                    book.Desc = Newbook.Desc;
                    book.Title = Newbook.Title;
                }
                else   //book does`t exist -> add the new book to the existing author
                {
                    author.Book.Add(new Book()
                    {
                        Title = Newbook.Title,
                        Name = Newbook.Name,
                        Desc = Newbook.Desc
                    });
                } 
            }

            //save
            dbContext.Authors.Update(author);
            await dbContext.SaveChangesAsync();

            return "Author Updated Successfully";
        }



        public async Task<string> DeleteData(int id)
        {
            var data = await dbContext.Authors.Where(b => b.Id == id).ExecuteDeleteAsync();
            if (data == 0) throw new Exception("No data founded....");
            return "successfully deleted";
        }


    }
}






