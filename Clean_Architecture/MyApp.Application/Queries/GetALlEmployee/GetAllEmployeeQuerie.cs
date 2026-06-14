
using MediatR;
using MyApp.Domain.DTO;

namespace MyApp.Application.Queries.GetALlEmployee
{
    public record GetAllEmployeeQuerie() : IRequest<IEnumerable<EmployeeDTO>>;

}
