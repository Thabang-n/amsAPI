using Domain.Models.AssetModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.LocationModel
{
    public class Location
    {
        [Key]
        public Guid LocationId { get; set; }

        [MaxLength(100)]
        public string LocationName { get; set; }

        [MaxLength(255)]
        public string LocationAddress { get; set; }

        [MaxLength(100)]
        public string LocationState { get; set; }

        [MaxLength(100)]
        public string LocationCity { get; set; }

        public ICollection<Asset> Assets { get; set; }
    }
}
