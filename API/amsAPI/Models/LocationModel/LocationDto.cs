using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.LocationModel
{
    public class LocationDto
    {
        [Key]
        public Guid LocationId { get; set; }
        public string LocationCity { get; set; }
    }
}
