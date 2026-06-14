
using MyApp.Domain.Entity;

namespace MyApp.Domain.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<Employe> AddNewEmployeeAsync(Employe Employe);
        Task<List<Employe>> GetAllEmployeeAsync();
        Task<Employe?> GetEmployeeByIDAsync(Guid Id);
        Task<int> UpdateEmployeeAysnc(Guid Id, Employe Employe);
        Task<int> DeleteEmployeeByID(Guid Id);

    }
}



