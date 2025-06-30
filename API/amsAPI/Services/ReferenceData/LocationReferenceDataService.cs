using amsAPI.Repositories.GenericRepository;
using amsAPI.Services.ReferenceData.mapper;
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

        private readonly IGenericRepo<Location> _locationRepo;


        public LocationReferenceDataService(IGenericRepo<Location> locationRepo)
        {

            _locationRepo = locationRepo;

        }


        public async Task<List<LocationDto>> GetLocations()
        {
            return LocationResponseMapper.toDTOList(await _locationRepo.GetAll());
        }

    }
}
