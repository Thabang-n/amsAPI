using amsAPI.Models.EmployeeModel;

namespace amsAPI.Services.EmployeeServ
{
    public interface IEmployeeService
    {
        Task<List<EmployeeResponseDto>> GetAllEmployeesAsync(string? search);
    }
}
