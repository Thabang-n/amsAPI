using amsAPI.Mapper;
using amsAPI.Repositories.ReferenceData.FeatureRepository;
using Domain.Models.FeatureModel;

namespace amsAPI.Services.ReferenceData
{
    public class FeatureReferenceDataService
    {
        private readonly IFeatureRepo _featureRepo;

        public FeatureReferenceDataService(IFeatureRepo featureRepo)
        {
            _featureRepo = featureRepo;
        }
        public async Task<List<FeatureDto>> GetAll(Guid? id)
        {
            return FeatureResponseMapper.ConvertToDto(await _featureRepo.GetAll(id));
        }
    }
}
