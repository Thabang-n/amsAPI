using amsAPI.Models.AssignmentModel;
using Domain.Data;
using Microsoft.EntityFrameworkCore;

namespace amsAPI.Repositories.AssignmentRepository
{
    public class AssignmentRepo:IAssignmentRepo
    {
        private readonly amsDbContext _context;

        public AssignmentRepo(amsDbContext context)
        {
            _context = context;
        }

        public async Task<AssignmentMdl> Add(AssignmentMdl assignmentMdl)
        {
            await _context.Assignments.AddAsync(assignmentMdl);
            await _context.SaveChangesAsync();
            return assignmentMdl;
        }

        public async Task<bool> IsAssetAlreadyAssignedAsync(Guid assetId)
        {
            return await _context.Assignments.AnyAsync(asset => asset.AssetId == assetId && asset.IsLinked); 
          
        }
    }
}
