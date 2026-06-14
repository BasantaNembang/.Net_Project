using MediatR;
using MyApp.Domain.DTO;

namespace MyApp.Application.Commands.UpdateEmployee
{
    public record UpdateEmployeeCommand(Guid Id, EmployeeDTO EmployeeDTO) :
        IRequest<string>;

}
