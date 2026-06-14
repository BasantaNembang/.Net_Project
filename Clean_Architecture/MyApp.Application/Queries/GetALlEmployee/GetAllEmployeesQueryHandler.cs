using MediatR;
using MyApp.Domain.DTO;
using MyApp.Domain.Interfaces;

namespace MyApp.Application.Queries.GetALlEmployee

{
    public class GetAllEmployeesQueryHandler(IEmployeeRepository _repository) 
        : IRequestHandler<GetAllEmployeeQuerie, IEnumerable<EmployeeDTO>>
    {
       public async Task<IEnumerable<EmployeeDTO>> Handle(GetAllEmployeeQuerie request,
            CancellationToken cancellationToken)
        {
            var employees = await _repository.GetAllEmployeeAsync();

            var result = employees
                .Select(x => new EmployeeDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Address = x.Address,
                    Department = x.Department
                })
                .ToList();

            return result;
        }
    }
}
              
       



