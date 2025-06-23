using Domain.Models.AssignmentModel;
using Domain.Models.AuditTrailModel;
using Domain.Models.MaintenanceModel;
using Domain.Models.RequestModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.EmployeeModel
{
    public class Employee
    {
        [Key]
        public Guid EmployeeId { get; set; }

        [MaxLength(100)]
        public string Username { get; set; }

        [MaxLength(255)]
        public string Email { get; set; }

        public bool IsAdmin { get; set; }

        public ICollection<AssignmentMdl> AdminAssignments { get; set; }
        public ICollection<AssignmentMdl> EmployeeAssignments { get; set; }
        public ICollection<RequestMdl> Requests { get; set; }
        public ICollection<AuditTrail> AuditTrails { get; set; }
        public ICollection<Maintenance> Maintenances { get; set; }
    }
}
