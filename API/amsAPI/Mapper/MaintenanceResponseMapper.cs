using amsAPI.Models.AssetModel;
using amsAPI.Models.EmployeeModel;
using amsAPI.Models.MaintenanceModel;
using Domain.Models.CategoryModel;
using Domain.Models.LocationModel;
using Domain.Models.MaintenanceModel;

namespace amsAPI.Mapper
{
    public class MaintenanceResponseMapper
    {

        public static List<ResponseMaintenanceDto> MapToDto(List<Maintenance> maintenance)
        {
            return maintenance.Select (e => new ResponseMaintenanceDto
            {
                MaintenanceId =e.MaintenanceId,
                EmployeeId = e.EmployeeId,
                EmployeeName   = e.Employee.Username,
                AssetSerialNumber = e.Asset.SerialNumber,
                Status = e.Status,
                MaintenanceDate = e.MaintenanceDate,
                Description = e.Description,
                LocationName = e.Location.LocationName
            }).ToList();
        }
    }
}


