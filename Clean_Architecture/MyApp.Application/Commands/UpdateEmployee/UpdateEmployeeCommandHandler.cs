using MediatR;
using MyApp.Application.Exceptions;
using MyApp.Domain.Entity;
using MyApp.Domain.Interfaces;

namespace MyApp.Application.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommandHandler(IEmployeeRepository _repository) :
        IRequestHandler<UpdateEmployeeCommand, string>
    {
        public async Task<string> Handle(UpdateEmployeeCommand request,
            CancellationToken cancellationToken)
        {
            var employee = new Employe()
            {
                Name = request.EmployeeDTO.Name,
                Department = request.EmployeeDTO.Department,
                Address = request.EmployeeDTO.Address,
            };
            var result = await _repository.UpdateEmployeeAysnc(request.Id, employee);

            if (result == 0) throw new NotFoundException("User not found! can`t perform UPDATE OPERATION");

            return "successfully updated";
        }
    }
}


