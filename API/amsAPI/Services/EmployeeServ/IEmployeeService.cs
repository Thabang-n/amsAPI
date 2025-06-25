using amsAPI.Models.EmployeeModel;
using System.Threading.Tasks;

namespace amsAPI.Services.EmployeeServ
{
    public interface IEmployeeService
    {
        Task<List<EmployeeResponseDto>> GetAllEmployeesAsync(string? search);

        Task EnsureEmployeeExistsAsync(Guid empId,string username,string email);
    }
}
