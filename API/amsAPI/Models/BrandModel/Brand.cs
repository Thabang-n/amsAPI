using Domain.Models.AssetModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.BrandModel
{
    public class Brand
    {
        [Key]
        public Guid BrandId { get; set; }

        [MaxLength(100)]
        public string BrandName { get; set; }

        public ICollection<Asset> Assets { get; set; }
    }
}
