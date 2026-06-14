using MediatR;
using MyApp.Domain.DTO;

namespace MyApp.Application.Queries.GetEmployeeByID
{
    public record GetEmployeeByIdQuerie(Guid Id) : IRequest<EmployeeDTO>;
 
}



