using amsAPI.Models.EmployeeModel;
using Domain.Data;
using Domain.Models.EmployeeModel;
using Microsoft.EntityFrameworkCore;

namespace amsAPI.Repositories.EmployeeRepository
{
    public class EmployeeRepo:IEmployeeRepo
    {
        private readonly amsDbContext _dbcontext;
        public EmployeeRepo(amsDbContext context)
        {
           _dbcontext = context; 
        }

        public async Task<Employee> AddAsync(Employee employee)
        {
            await _dbcontext.Employees.AddAsync(employee);
            await _dbcontext.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee?> EmployeeExistsByActiveAdIdAsync(Guid Id)
        {
            return await _dbcontext.Employees.FirstOrDefaultAsync(emp => emp.EmployeeId == Id);
        }

        public Task<List<Employee>> GetAllAsync(string? search)
        {
            IQueryable<Employee> query = _dbcontext.Employees;

            if (!string.IsNullOrWhiteSpace(search))
            {
                 query = query.Where(emp => emp.Email.Contains(search) || emp.Username.Contains(search));
            }
            return query.AsNoTracking().ToListAsync();
        }
    }
}
