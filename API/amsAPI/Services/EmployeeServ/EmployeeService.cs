using amsAPI.Mapper;
using amsAPI.Models.EmployeeModel;
using amsAPI.Repositories.EmployeeRepository;
using Domain.Models.EmployeeModel;

namespace amsAPI.Services.EmployeeServ
{
    public class EmployeeService
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
                //throw new InvalidOperationException("Employee already exists.");
                
            }

            var newEmployee = EmployeeMapper.MaptoDomain(empId, username, email); 
            await _employeeRepo.AddAsync(newEmployee);
        }

        public async Task<List<EmployeeResponseDto>> GetAllEmployeesAsync(string? search)
        {
            var employees = await _employeeRepo.GetAllAsync(search);
            return EmployeeResponseMapper.MapToDto(employees);
            
        }
    }
}
