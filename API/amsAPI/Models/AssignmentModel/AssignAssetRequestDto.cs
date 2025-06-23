using Domain.Models.AssetModel;
using Domain.Models.EmployeeModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace amsAPI.Models.AssignmentModel
{
    public class AssignAssetRequestDto
    {
        [Required]
        public Guid AssetId { get; set; }
        [Required]
        public Guid AdminId { get; set; }
        [Required]
        public Guid EmployeeId { get; set; }
    }
}
