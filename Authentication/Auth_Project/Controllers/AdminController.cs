using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auth_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GettingThePrivateMessage()
        {
            return Ok("private message");
        }


    }
}







