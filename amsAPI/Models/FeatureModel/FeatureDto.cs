using Domain.Models.CategoryModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.FeatureModel
{
    public class FeatureDto
    {
        [Key]
        public Guid FeatureId { get; set; }
        [MaxLength(100)]
        public string FeatureKey { get; set; }

        public CategoryDto Category { get; set; }
    }
    }

