using Domain.Models.LocationModel;

namespace amsAPI.Services.ReferenceData.mapper
{
    public class LocationResponseMapper
    {
        public static List<LocationDto> toDTOList(List<Location> locations)
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
