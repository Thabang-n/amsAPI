using System.ComponentModel.DataAnnotations;

namespace amsAPI.Models.EmployeeModel
{
    public class EmployeeDto
    {
        public Guid EmployeeId { get; set; }

        [MaxLength(100)]
        public string Username { get; set; }
    }
}
