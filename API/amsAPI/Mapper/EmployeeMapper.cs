using amsAPI.Models.EmployeeModel;
using Domain.Models.EmployeeModel;

namespace amsAPI.Mapper
{
    public class EmployeeMapper
    {
        public static Employee MaptoDomain(Guid empId, string username, string email)
        {
            return new Employee
            {
                EmployeeId = empId,
                Email = email,
                Username = username
            };

        }
    }
}


