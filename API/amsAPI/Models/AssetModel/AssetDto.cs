
using Domain.Models.BrandModel;
using Domain.Models.CategoryModel;
using Domain.Models.LocationModel;
using Domain.Models.MaintenanceModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.AssetModel
{
    public class AssetDto
    {
        [Key]
        public Guid Id { get; set; }

        public CategoryDto Category { get; set; }
        public LocationDto Location { get; set; }
        public BrandDto Brand { get; set; }

        public string SerialNumber { get; set; }
        public string Description { get; set; }
        public bool IsAssigned { get; set; }

        public List<AddAssetrequestAttributeDto> AssetAttributes { get; set; }

    }
}
