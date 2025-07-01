using amsAPI.mapper;
using amsAPI.Repositories.ReferenceData.LocationRepository;
using Domain.Data;
using Domain.Models.BrandModel;
using Domain.Models.CategoryModel;
using Domain.Models.FeatureModel;
using Domain.Models.LocationModel;
using Microsoft.EntityFrameworkCore;


namespace Services.ReferenceData
{
    public class LocationReferenceDataService
    {

        private readonly ILocationRepo _locationRepo;
        public LocationReferenceDataService(ILocationRepo locationRepo)
        {
           this._locationRepo = locationRepo;
        }

        public async Task<List<LocationDto>> GetLocations()
        {
            return LocationResponseMapper.toDtOList(await _locationRepo.GetAll());
        }

    }
}
