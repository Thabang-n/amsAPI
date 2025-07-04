using Domain.Models.FeatureModel;

namespace amsAPI.Repositories.ReferenceData.FeatureRepository
{
    public interface IFeatureRepo
    {
        Task<List<Feature>> GetAll(Guid? id);
    }
}
