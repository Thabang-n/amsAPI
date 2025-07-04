using Domain.Models.LocationModel;

namespace amsAPI.mapper
{
    public class LocationResponseMapper
    {
        public static List<LocationDto> toDtOList(List<Location> locations)
        {
            return locations.Select(location => new LocationDto
            {
                LocationId = location.LocationId,
                LocationCity = location.LocationCity,
                LocationName = location.LocationName,
            }).ToList();

        }
    }
}
