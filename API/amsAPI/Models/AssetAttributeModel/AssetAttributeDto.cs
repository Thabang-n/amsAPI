using Domain.Models.FeatureModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.AssetAttributeModel
{
    public class AssetAttributeDto
    {
        [Key]
        public Guid AssetAttributeId { get; set; }
        [Required]

        [MaxLength(255)]
        public string Value { get; set; }
    }
}

