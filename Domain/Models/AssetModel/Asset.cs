using Domain.Models.AssetAttributeModel;
using Domain.Models.AssignmentModel;
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
    public class Asset
    {
        [Key]
        public Guid AssetId { get; set; }

        [Required]
        public Guid CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        [Required]
        public Guid LocationId { get; set; }
        [ForeignKey("LocationId")]
        public LocationDto Location { get; set; }

        [Required]
        public Guid BrandId { get; set; }
        [ForeignKey("BrandId")]
        public Brand Brand { get; set; }

        [MaxLength(100)]
        public string SerialNumber { get; set; }

        public bool IsAssigned { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<AssetAttribute> AssetAttributes { get; set; }
        public ICollection<Assignment> Assignments { get; set; }
        public ICollection<Maintenance> Maintenances { get; set; }
    }
}
