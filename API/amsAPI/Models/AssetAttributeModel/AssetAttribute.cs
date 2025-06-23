using Domain.Models.AssetModel;
using Domain.Models.FeatureModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.AssetAttributeModel
{
    public class AssetAttribute
    {
        [Key]
        public Guid AssetAttributeId { get; set; }

        [Required]
        public Guid AssetId { get; set; }
        [ForeignKey("AssetId")]
        public Asset Asset { get; set; }

        [Required]
        public Guid FeatureId { get; set; }
        [ForeignKey("FeatureId")]
        public Feature Feature { get; set; }

        [Required]
        [MaxLength(255)]
        public string Value { get; set; }
    }
}
