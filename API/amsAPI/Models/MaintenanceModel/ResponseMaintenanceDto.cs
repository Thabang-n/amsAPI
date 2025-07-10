using Domain.Models.AssetModel;
using Domain.Models.EmployeeModel;
using Domain.Models.LocationModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using amsAPI.Models.EmployeeModel;
using amsAPI.Models.AssetModel;

namespace amsAPI.Models.MaintenanceModel
{
    public class ResponseMaintenanceDto
    {
        [Key]
        public Guid MaintenanceId { get; set; }
        public string AssetSerialNumber { get; set; }
        public string AssetCategory { get; set; }


        public Guid EmployeeId { get; set; }
        public string EmployeeName { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }


        public string LocationName { get; set; }

        public DateTime MaintenanceDate { get; set; }

    }
}

