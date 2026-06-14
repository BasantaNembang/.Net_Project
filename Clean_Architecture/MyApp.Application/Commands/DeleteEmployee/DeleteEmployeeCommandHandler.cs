using MediatR;
using MyApp.Application.Exceptions;
using MyApp.Domain.Interfaces;

namespace MyApp.Application.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommandHandler(IEmployeeRepository _reposistory) :
        IRequestHandler<DeleteEmployeeCommand, string>
    {

        public async Task<string> Handle(DeleteEmployeeCommand request,
            CancellationToken cancellationToken)
        {
            var result = await _reposistory.DeleteEmployeeByID(request.Id);

            if (result == 0) throw new NotFoundException("user Not found! Failed DELECETION");

            return "Delete Success";
        }
    }

}

