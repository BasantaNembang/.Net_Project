using Microsoft.AspNetCore.Mvc;
using Project_One.DTO;
using Project_One.Service.Interfaces;

namespace Project_One.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase{

        private readonly IBookService bookService;

        public BookController(IBookService bookService) {
            this.bookService = bookService;
        }


        //get-all result
        [HttpGet("")]
        public async Task<IActionResult> GetAllBooks(){
            var datas = await bookService.GetAllBooksAsync();
            return Ok(datas);
        }

        //get result by id
        //[HttpGet("")]
        //public async Task<IActionResult> GetAllBooks()
        //{
        //    var datas = await bookService.GetAllBooksAsync();
        //    return Ok(datas);
        //}


        //add new data
        [HttpPost("save")]
        public async Task<IActionResult> SaveBook([FromBody] BookDTO book){
          var data = await bookService.CreateBook(book);
          return Ok(data);
        }



    }
}
