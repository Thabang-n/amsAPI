using amsAPI.Models.EmployeeModel;

using Domain.Data;
using Domain.Models.EmployeeModel;
using Microsoft.EntityFrameworkCore;

namespace amsAPI.Repositories.EmployeeRepository
{
    public class EmployeeRepo:IEmployeeRepo
    {
        private readonly amsDbContext _context;
        public EmployeeRepo(amsDbContext context)
        {
           this._context = context; 
        }

        public async Task<Employee> Add(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee?> EmployeeExistsByActiveAdIdAsync(Guid Id)
        {
            return await _context.Employees.FirstOrDefaultAsync(emp => emp.EmployeeId == Id);
        }

        public Task<List<Employee>> GetAllAsync(string? search)
        {
            IQueryable<Employee> query = _context.Set<Employee>();

            if (!string.IsNullOrWhiteSpace(search))
            {
                 query = query.Where(emp => emp.Email.Contains(search) || emp.Username.Contains(search));
            }
            return query.ToListAsync();
        }
    }
}
