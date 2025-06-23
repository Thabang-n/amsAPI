using amsAPI.Models.AssignmentModel;
using amsAPI.Repositories.GenericRepository;
using Domain.Data;
using Microsoft.EntityFrameworkCore;

namespace amsAPI.Repositories.AssignmentRepository
{
    public class AssignmentRepo : GenericRepo<AssignmentMdl>, IAssignmentRepo
    {
        private readonly amsDbContext _context;

        public AssignmentRepo(amsDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<bool> IsAssetAlreadyAssignedAsync(Guid assetId)
        {
            return await _context.Assignments.AnyAsync(asset => asset.AssetId == assetId && asset.IsLinked); 
          
        }
    }
}
