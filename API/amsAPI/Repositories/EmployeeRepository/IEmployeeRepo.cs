using amsAPI.Models.EmployeeModel;
using amsAPI.Repositories.GenericRepository;
using Domain.Models.EmployeeModel;

namespace amsAPI.Repositories.EmployeeRepository
{
    public interface IEmployeeRepo:IGenericRepo<Employee>
    {
        Task<List<Employee>> GetAllAsync(string? search);

        Task<Employee?> EmployeeExistsByActiveAdIdAsync(Guid Id);
    }
}
 