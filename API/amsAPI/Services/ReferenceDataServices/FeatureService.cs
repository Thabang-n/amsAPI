using amsAPI.Mapper;
using amsAPI.Repositories.ReferenceDataRepository.FeatureRepository;
using Domain.Models.FeatureModel;

namespace amsAPI.Services.ReferenceDataServices
{
    public class FeatureService
    {
        public IFeatureRepo _featureRepo { get; }
        public FeatureService(IFeatureRepo featureRepo)
        {
            _featureRepo = featureRepo;
        }

        public async Task<List<FeatureDto>> GetAllFeatures(Guid id)
        {
            var features = await _featureRepo.GetFeatures(id);

            return FeatureResponseMapper.ToDtoList(features);
        }
    }
};
