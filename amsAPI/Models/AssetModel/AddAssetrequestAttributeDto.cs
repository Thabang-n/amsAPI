using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.AssetModel
{
    public class AddAssetrequestAttributeDto
    {
        [Required]
        public Guid FeatureId { get; set; }

        [Required]
        public string Value { get; set; }
    }
}
