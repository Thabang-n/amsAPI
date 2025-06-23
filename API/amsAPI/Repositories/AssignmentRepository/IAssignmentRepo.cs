using amsAPI.Models.AssignmentModel;
using amsAPI.Repositories.GenericRepository;

namespace amsAPI.Repositories.AssignmentRepository
{
    public interface IAssignmentRepo : IGenericRepo<AssignmentMdl>
    {
        Task<bool> IsAssetAlreadyAssignedAsync(Guid assetId);
    }
}

