using Domain.Models.AssetModel;
using Domain.Models.EmployeeModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.MaintenanceModel
{
    public class Maintenance
    {
        [Key]
        public Guid MaintenanceId { get; set; }

        [Required]
        public Guid AssetId { get; set; }
        [ForeignKey("AssetId")]
        public Asset Asset { get; set; }

        [Required]
        public Guid EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }

        public string Description { get; set; }

        [MaxLength(50)]
        public string Status { get; set; }

        public DateTime MaintenanceDate { get; set; }
    }
}
