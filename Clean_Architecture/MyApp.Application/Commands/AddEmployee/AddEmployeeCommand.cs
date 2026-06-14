using MediatR;
using MyApp.Domain.DTO;

namespace MyApp.Application.Commands.AddEmployee
{
    public record AddEmployeeCommand(EmployeeDTO EmployeeDTO) :
    IRequest<EmployeeDTO>;

}
