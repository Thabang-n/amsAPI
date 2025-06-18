using Domain.Models.FeatureModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace amsAPI.Models.FeatureValueModel
{
    public class FeatureValue
    {
        [Key]
        public Guid FeatureValueId { get; set; }

        [ForeignKey("Feature")]
        public Guid FeatureId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Value { get; set; }


        public virtual Feature Feature { get; set; }
    }
}
