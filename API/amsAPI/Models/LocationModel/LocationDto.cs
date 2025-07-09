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

        [MaxLength(255)]
        public string LocationCity { get; set; }


        [MaxLength(255)]
        public string LocationName { get; set; }
    }
}
