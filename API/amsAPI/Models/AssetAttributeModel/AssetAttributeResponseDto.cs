using Domain.Models.FeatureModel;
using System.ComponentModel.DataAnnotations;

namespace amsAPI.Models.AssetAttributeModel
{
    public class AssetAttributeResponseDto
    {
        [Key]
        public Guid AssetAttributeId { get; set; }
        [Required]
        public FeatureDto Feature { get; set; }

        [Required]
        [MaxLength(255)]
        public string Value { get; set; }
    }
}