using System.ComponentModel.DataAnnotations;

namespace amsAPI.Models.EmployeeModel
{
    public class EmployeeResponseDto
    {
        public Guid EmployeeId { get; set; }

        [MaxLength(100)]
        public string Username { get; set; }

        [MaxLength(255)]
        public string Email { get; set; }

       
    }
}
