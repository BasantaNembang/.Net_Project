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
        [HttpGet()]
        public async Task<IActionResult> GetAllBooks(){
            var datas = await bookService.GetAllBooksAsync();
            return Ok(datas);
        }

        //get result by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetABook([FromRoute] int id){
            var data = await bookService.GetBookByIDAsync(id);
            return Ok(data);
        }


        //add new data
        [HttpPost("save")]
        public async Task<IActionResult> SaveBook([FromBody] BookDTO book){
          var data = await bookService.CreateBook(book);
          return Ok(data);
        }


        //update the data
        [HttpPut("update")]
        public async Task<IActionResult> UpDateData([FromQuery] int id,
            [FromBody] BookDTO book)
        {
            var data = await bookService.UpdateTheBodyAysnc(id, book);
            return Ok(data);
        }



        //optimize-update 
        [HttpPut()]
        public async Task<IActionResult> UpDateDataO([FromBody] BookDTO book)
        {
            var data = await bookService.UpdateTheBodyAysncO(book);
            return Ok(data);
        }



        //optimize-update 
        [HttpDelete()]
        public async Task<IActionResult> UpDateDataO([FromRoute] int id)
        {
            var data = await bookService.DeleteTheDataAsync(id);
            return Ok(data);
        }

    }
}
