using MediatR;
using MyApp.Application.Events.UserCreated;
using MyApp.Domain.DTO;
using MyApp.Domain.Entity;
using MyApp.Domain.Interfaces;

namespace MyApp.Application.Commands.AddEmployee
{
    public class AddEmployeeCommandHandler(IEmployeeRepository Repository, IPublisher _publisher) :
        IRequestHandler<AddEmployeeCommand, EmployeeDTO>
    {
        public async Task<EmployeeDTO> Handle(AddEmployeeCommand request,
            CancellationToken cancellationToken)
        {
            var employeeDTO = request.EmployeeDTO;

            var employee = new Employe()
            {
                Id = Guid.NewGuid(),
                Name = employeeDTO.Name,
                Address = employeeDTO.Address,
                Department = employeeDTO.Department,
            };

            await Repository.AddNewEmployeeAsync(employee);

            await _publisher.Publish(new UserCreatedEvent(), cancellationToken);


            employeeDTO.Id = employee.Id;
            return employeeDTO;
        }
    }
    
}




