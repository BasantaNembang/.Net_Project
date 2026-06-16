using Auth_Project.DTO;
using Auth_Project.Services.Helper;
using Auth_Project.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Auth_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService,
        RefreshTokenHelper refreshHelper) : ControllerBase
    {

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserDto user)
        {
            var data = await authService.RegisterNewUserAysnc(user);

            if (data == null) return BadRequest("Already Exits");

            return Ok(data);
        }


        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody] UserDto user)
        {
            var data = await authService.LoginUser(user);

            if (data == null) return BadRequest("username/password miss-match");

            return Ok(data);
        }



        [HttpPost("refresh-token")]
        public async Task<IActionResult> GetRefreshToken([FromBody] RefreshRequestDTO refreshRequest)
        {
            var response = await refreshHelper.GenerateRefreshToken(refreshRequest);

            return Ok(response);
        }


    }
}
