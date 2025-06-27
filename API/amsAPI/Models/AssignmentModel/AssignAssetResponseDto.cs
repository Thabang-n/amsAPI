using amsAPI.Models.EmployeeModel;
using Domain.Models.LocationModel;

namespace amsAPI.Models.AssignmentModel
{
    public class AssignAssetResponseDto
    {
        public AssignedAssetDto assignedAsset { get; set; } = default!;
        public EmployeeDto Admin { get; set; } = default!;
        public EmployeeDto Employee { get; set; } = default!;
        public DateTime DateAssigned { get; set; }
        public bool IsLinked { get; set; }
        public LocationDto Location { get; set; } = default!;
    }
}
