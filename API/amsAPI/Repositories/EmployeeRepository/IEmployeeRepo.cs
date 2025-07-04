using amsAPI.Models.EmployeeModel;
using Domain.Models.EmployeeModel;

namespace amsAPI.Repositories.EmployeeRepository
{
    public interface IEmployeeRepo
    {
        Task<List<Employee>> GetAllAsync(string? search);
        Task<Employee> Add(Employee employee);
        Task<Employee?> EmployeeExistsByActiveAdIdAsync(Guid Id);
    }
}
 