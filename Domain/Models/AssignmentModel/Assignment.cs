using Domain.Models.AssetModel;
using Domain.Models.EmployeeModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.AssignmentModel
{
    public class Assignment
    {
        [Key]
        public Guid AssignmentId { get; set; }

        [Required]
        public Guid AssetId { get; set; }
        [ForeignKey("AssetId")]
        public Asset Asset { get; set; }

        [Required]
        public Guid AdminId { get; set; }
        [ForeignKey("AdminId")]
        public Employee Admin { get; set; }

        [Required]
        public Guid EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }

        public DateTime AssignedDate { get; set; }
        public bool IsLinked { get; set; } = false;
    }
}
