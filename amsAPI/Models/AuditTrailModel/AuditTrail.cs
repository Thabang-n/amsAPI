using Domain.Models.EmployeeModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.AuditTrailModel
{
    public class AuditTrail
    {
        [Key]
        public Guid AuditTrailId { get; set; }

        [MaxLength(50)]
        public string AuditTrailAction { get; set; }

        [MaxLength(100)]
        public string EntityName { get; set; }

        public Guid RecordId { get; set; }

        [Required]
        public Guid PerformedById { get; set; }
        [ForeignKey("PerformedById")]
        public Employee PerformedBy { get; set; }

        [MaxLength(50)]
        public string PerformedByRole { get; set; }

        public DateTime TimeStamp { get; set; }
        public string Details { get; set; }
    }
}
