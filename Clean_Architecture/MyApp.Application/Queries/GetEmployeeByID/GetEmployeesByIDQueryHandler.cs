using MediatR;
using MyApp.Application.Exceptions;
using MyApp.Domain.DTO;
using MyApp.Domain.Interfaces;

namespace MyApp.Application.Queries.GetEmployeeByID
{
    public class GetEmployeesByIDQueryHandler(IEmployeeRepository repository) :
        IRequestHandler<GetEmployeeByIdQuerie, EmployeeDTO>
    {

        public async Task<EmployeeDTO> Handle(GetEmployeeByIdQuerie request,
            CancellationToken cancellationToken)
        {
            var employee = await repository.GetEmployeeByIDAsync(request.Id);

            if (employee == null) throw new NotFoundException("Not Found User");

            return new EmployeeDTO()
            {
                Id = employee.Id,
                Name = employee.Name,
                Address = employee.Address,
                Department = employee.Department,
            };

        }
    }
}


