using amsAPI.Models.EmployeeModel;
using Domain.Models.EmployeeModel;

namespace amsAPI.Mapper
{
    public class EmployeeResponseMapper
    {
        public static List<EmployeeResponseDto> MapToDto(List<Employee> employees)
        {
            return employees.Select(e => new EmployeeResponseDto
            {
                EmployeeId = e.EmployeeId,
                Email = e.Email,
                Username = e.Username
            }).ToList();
        }

    }
}
