using Domain.Data;
using Domain.Models.FeatureModel;
using Microsoft.EntityFrameworkCore;

namespace amsAPI.Repositories.ReferenceDataRepository.FeatureRepository
{
    public class FeatureRepo : IFeatureRepo
    {
        public amsDbContext _dbcontext { get; }
        public FeatureRepo(amsDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }


        public async Task<List<Feature>> GetFeatures(Guid categoryId)
        {
            var features = await _dbcontext.Features.Where(x => x.CategoryId == categoryId).ToListAsync(); ;
            return features;
        }
    }
}
