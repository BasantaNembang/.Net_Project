
using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Entity;
using MyApp.Domain.Interfaces;
using MyApp.Infrastructure.Data;

namespace MyApp.Infrastructure.Repository
{
    public class EmployeeRepository(AppDbContext dbContext) : IEmployeeRepository
    {

        public async Task<Employe> AddNewEmployeeAsync(Employe Employe)
        {
           dbContext.Employes.Add(Employe);
           await dbContext.SaveChangesAsync();
           return Employe;
         }


        public async Task<List<Employe>> GetAllEmployeeAsync()
        {
            return await dbContext.Employes.ToListAsync();
        }



        public async Task<Employe?> GetEmployeeByIDAsync(Guid Id)
        {
            var employee =  await dbContext.Employes.FirstOrDefaultAsync(e => e.Id == Id);

            if (employee == null) return null;

            return employee;   
        }



        public async Task<int> DeleteEmployeeByID(Guid Id)
        {
            var result = await dbContext.Employes.Where(e => e.Id == Id).ExecuteDeleteAsync();
            return result;
        }



        public async Task<int> UpdateEmployeeAysnc(Guid Id, Employe Employe)
        {
           var employee = await dbContext.Employes
                .FirstOrDefaultAsync(e => e.Id == Id);

           if (employee == null) return 0;

           employee?.Department = Employe.Department;
           employee?.Name = Employe.Name;
           employee?.Address = Employe.Address;

           var result = await dbContext.SaveChangesAsync();

           return result;

        }
    }
}



