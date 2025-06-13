using Domain.Models.CategoryModel;
using Domain.Models.EmployeeModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.RequestModel
{
    public class RequestMdl
    {
        [Key]
        public Guid RequestId { get; set; }

        [Required]
        public Guid EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }

        [Required]
        public Guid CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        public DateTime RequestDate { get; set; }
        public string Description { get; set; }

        [MaxLength(20)]
        public string Status { get; set; }
    }
}
