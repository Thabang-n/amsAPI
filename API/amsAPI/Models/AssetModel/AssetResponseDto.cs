using amsAPI.Models.AssetAttributeModel;
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

        public LocationDto Location { get; set; }
        public BrandDto Brand { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public string SerialNumber { get; set; }
        public string Description { get; set; }
        public bool IsAssigned { get; set; }

        public List<AssetAttributeResponseDto> AssetAttributes { get; set; }
    }
}
