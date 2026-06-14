using Microsoft.AspNetCore.Mvc;
using Project_One.DTO;
using Project_One.Service.Interfaces;

namespace Project_One.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OneToManyController : ControllerBase
    {


        private readonly IOneToMany service;
        public OneToManyController(IOneToMany service)
        {
            this.service = service;
        }


        //add new data
        [HttpPost("save")]
        public async Task<IActionResult> SaveAuthor([FromBody] AuthorDTO author)
        {
            var data = await service.CreateAuthorAsync(author);
            return Ok(data);
        }


        //get-all result
        [HttpGet()]
        public async Task<IActionResult> GetAllBooks()
        {
            var datas = await service.GetAllAuthorsAsync();
            return Ok(datas);
        }



        //get result by Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthorBYIDAync([FromRoute] int id)
        {
            var datas = await service.GetAuthorByIDAsync(id);
            return Ok(datas);
        }


        //update the data
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTheAuthorAsync([FromRoute] int id, AuthorDTO author)
        {
            var datas = await service.UpdateTheBodyAysnc(id, author);
            return Ok(datas);
        }


        //delete the data
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteData([FromRoute] int id)
        {
            var datas = await service.DeleteData(id);
            return Ok(datas);
        }


    }
}

