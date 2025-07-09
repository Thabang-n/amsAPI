using amsAPI.Models.AssignmentModel;
using Domain.Data;
using Microsoft.EntityFrameworkCore;

namespace amsAPI.Repositories.AssignmentRepository
{
    public class AssignmentRepo : IAssignmentRepo
    {
        private readonly amsDbContext _dbcontext;

        public AssignmentRepo(amsDbContext context) 
        {
            _dbcontext = context;
        }

        public async Task<Assignment> AddAsync(Assignment assignAsset)
        {
            await _dbcontext.Assignments.AddAsync(assignAsset);
            await _dbcontext.SaveChangesAsync();
            return assignAsset;
        }

        public async Task<bool> IsAssetAlreadyAssignedAsync(Guid assetId)
        {
            return await _dbcontext.Assignments.AnyAsync(asset => asset.AssetId == assetId && asset.IsLinked); 
          
        }
    }
}
