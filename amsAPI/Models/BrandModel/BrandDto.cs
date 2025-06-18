using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.BrandModel
{
    public class BrandDto
    {
        [Key]
        public Guid BrandId { get; set; }

        [MaxLength(100)]
        public string BrandName { get; set; }
    }
}
