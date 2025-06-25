using amsAPI.Models.EmployeeModel;
using amsAPI.Repositories.GenericRepository;
using Domain.Data;
using Domain.Models.EmployeeModel;
using Microsoft.EntityFrameworkCore;

namespace amsAPI.Repositories.EmployeeRepository
{
    public class EmployeeRepo: GenericRepo<Employee>,IEmployeeRepo
    {
        private readonly amsDbContext _context;
        public EmployeeRepo(amsDbContext context):base(context)
        {
           this._context = context; 
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
