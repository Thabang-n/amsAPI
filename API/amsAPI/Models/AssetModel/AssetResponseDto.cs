using amsAPI.Models.AssetAttributeModel;

using amsAPI.Models.LocationModel;

using Domain.Models.AssetAttributeModel;
using Domain.Models.BrandModel;
using Domain.Models.CategoryModel;
using Domain.Models.LocationModel;
using System.ComponentModel.DataAnnotations;

namespace amsAPI.Models.AssetModel
{
    public class AssetResponseDto
    {
        [Key]
        public Guid Id { get; set; }

        public CategoryDto Category { get; set; }

        public LocationResponseDto Location { get; set; }
        public BrandDto Brand { get; set; }

        public string SerialNumber { get; set; }
        public string Description { get; set; }
        public bool IsAssigned { get; set; }

        public List<AssetAttributeResponseDto> AssetAttributes { get; set; }
    }
}
