using Domain.Models.BrandModel;
using Domain.Models.CategoryModel;
using Domain.Models.LocationModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.AssetModel
{
    public class AddAssetRequestDto
    {
        [Required]
        public Guid CategoryId { get; set; }
        [Required]
        public Guid LocationId { get; set; }
        [Required]
        public Guid BrandId { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
        public string SerialNumber { get; set; }

        public List<AddAssetrequestAttributeDto> AssetAttributes { get; set; } = new();
    }
}
