using Domain.Data;
using Domain.Models.FeatureModel;
using Microsoft.EntityFrameworkCore;

namespace amsAPI.Repositories.ReferenceData.FeatureRepository
{
    public class FeatureRepo : IFeatureRepo
    {
        private readonly amsDbContext _amsDbContext;

        public FeatureRepo(amsDbContext amsDbContext)
        {
            _amsDbContext = amsDbContext;
        }

        public async Task<List<Feature>> GetAll(Guid? id)
        {
            return await _amsDbContext.Features
                .Where(feature => !id.HasValue || feature.FeatureId == id.Value)
                .ToListAsync();
        }
    }
}
