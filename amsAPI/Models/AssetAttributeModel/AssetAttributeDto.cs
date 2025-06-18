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
        [Required]
        public Guid FeatureId { get; set; }
    }
}

