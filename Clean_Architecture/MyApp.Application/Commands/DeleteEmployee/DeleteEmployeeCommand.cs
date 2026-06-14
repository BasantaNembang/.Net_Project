
using MediatR;

namespace MyApp.Application.Commands.DeleteEmployee
{
    public record DeleteEmployeeCommand(Guid Id) :
        IRequest<string>;

}


