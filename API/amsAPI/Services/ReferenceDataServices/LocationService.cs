using amsAPI.mapper;
using amsAPI.Repositories.ReferenceDataRepository.LocationRepository;
using Domain.Models.LocationModel;



namespace amsAPI.Services.ReferenceDataServices
{
    public class LocationService
    {

        private readonly ILocationRepo _locationRepo;

        public LocationService(ILocationRepo repo)
        {
            _locationRepo = repo;
        }

        public async Task<List<LocationDto>> GetLocations()
        {
            var location = await _locationRepo.GetAllAsync();
            return LocationResponseMapper.toDTOList( location);
        }

        public async Task<LocationDto> GetLocationById(Guid id)
        {
            var location = await _locationRepo.GetById(id);
            return LocationResponseMapper.toDTO(location);
        }
    }
}
