using Microsoft.AspNetCore.Mvc;
using Project_One.DTO;
using Project_One.Service.Interfaces;

namespace Project_One.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OneToOneController : ControllerBase
    {

        private readonly IOneToOneBookService bookService;

        public OneToOneController(IOneToOneBookService bookService)
        {
            this.bookService = bookService;
        }



        //get all data
        [HttpGet("")]
        public async Task<IActionResult> GetAllData()
        {
            var datas = await bookService.GetAllDataAsync();
            return Ok(datas);
        }


        //add new data
        [HttpPost("save")]
        public async Task<IActionResult> SaveAuthor([FromBody] BookMDTO book)
        {
            var data = await bookService.CreateBook(book);
            return Ok(data);
        }



    }
}
