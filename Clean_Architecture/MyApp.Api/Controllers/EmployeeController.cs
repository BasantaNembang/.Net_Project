using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Commands.AddEmployee;
using MyApp.Application.Commands.DeleteEmployee;
using MyApp.Application.Commands.UpdateEmployee;
using MyApp.Application.Queries.GetALlEmployee;
using MyApp.Application.Queries.GetEmployeeByID;
using MyApp.Domain.DTO;

namespace MyApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController(ISender sender) : ControllerBase
    {


        [HttpPost]
        public async Task<IActionResult> AddEmployeeAysnc([FromBody] EmployeeDTO employeeDTO)
        {
            var result = await sender.Send(new AddEmployeeCommand(employeeDTO));
            return Ok(result);
        }



        [HttpGet]
        public async Task<IActionResult> GetAllEmployeeAysnc()
        {
            var result = await sender.Send(new GetAllEmployeeQuerie());
            return Ok(result);
        }


        [HttpGet("{Id}")]
        public async Task<IActionResult> GetEmployeeByIDAysnc([FromRoute] Guid Id)
        {
            var result = await sender.Send(new GetEmployeeByIdQuerie(Id));
            return Ok(result);
        }



        [HttpPut("update/{Id}")]
        public async Task<IActionResult> UpdateEmployeeAysnc([FromRoute] Guid Id,
            [FromBody] EmployeeDTO employeeDTO)
        {
            var result = await sender.Send(new UpdateEmployeeCommand(Id, employeeDTO));
            return Ok(result);
        }



        [HttpDelete("delete/{Id}")]
        public async Task<IActionResult> DeleteEmployeeAysnc([FromRoute] Guid Id)
        {
            var result = await sender.Send(new DeleteEmployeeCommand(Id));
            return Ok(result);
        }
    }

}






