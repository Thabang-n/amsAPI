using Domain.Models.AssetModel;
using Domain.Models.FeatureModel;
using Domain.Models.RequestModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.CategoryModel
{
    public class Category
    {
        [Key]
        public Guid CategoryId { get; set; }

        [MaxLength(100)]
        public string CategoryName { get; set; }

        public ICollection<Asset> Assets { get; set; }
        public ICollection<Feature> Features { get; set; }
        public ICollection<RequestMdl> Requests { get; set; }
    }
}
