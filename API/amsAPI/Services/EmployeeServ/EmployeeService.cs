using amsAPI.Models.EmployeeModel;
using amsAPI.Repositories.EmployeeRepository;

namespace amsAPI.Services.EmployeeServ
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepo _employeeRepo;
        public EmployeeService(IEmployeeRepo employeeRepo)
        {
          this._employeeRepo = employeeRepo; 
        }
        public async Task<List<EmployeeResponseDto>> GetAllEmployeesAsync(string? search)
        {
            var employees = await _employeeRepo.GetAllAsync(search);

            var empDto = employees.Select(emp => new EmployeeResponseDto
            {
                EmployeeId = emp.EmployeeId,
                Email = emp.Email,
                Username = emp.Username
            }).ToList();
            return empDto;
            
        }
    }
}
