using System.ComponentModel.DataAnnotations;

namespace amsAPI.Models.LocationModel
{
    public class LocationResponseDto
    {
        [Key]
        public Guid LocationId { get; set; }

        [MaxLength(100)]
        public string LocationName { get; set; }

        [MaxLength(100)]
        public string LocationCity { get; set; }

    }
}
