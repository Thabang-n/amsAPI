using Domain.Models.FeatureModel;

namespace amsAPI.Repositories.ReferenceDataRepository.FeatureRepository
{
    public interface IFeatureRepo
    {
        public Task<List<Feature>> GetFeatures(Guid categoryId);
    }
}
