using amsAPI.Models.EmployeeModel;
using amsAPI.Repositories.EmployeeRepository;
using Domain.Models.EmployeeModel;

namespace amsAPI.Services.EmployeeServ
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepo _employeeRepo;
        public EmployeeService(IEmployeeRepo employeeRepo)
        {
          this._employeeRepo = employeeRepo; 
        }

        public async Task EnsureEmployeeExistsAsync(Guid empId, string username, string email)
        {

            var existingEmployee = await _employeeRepo.EmployeeExistsByActiveAdIdAsync(empId);

            if (existingEmployee != null)
            {
                throw new InvalidOperationException("Employee already exists.");
            }

            var newEmployee = new Employee
            {
                EmployeeId = empId,
                Email = email,
                Username = username
            };

            await _employeeRepo.Add(newEmployee);
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
