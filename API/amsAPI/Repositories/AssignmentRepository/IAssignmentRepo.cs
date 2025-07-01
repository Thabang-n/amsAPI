using amsAPI.Models.AssignmentModel;


namespace amsAPI.Repositories.AssignmentRepository
{
    public interface IAssignmentRepo
    {
        Task<bool> IsAssetAlreadyAssignedAsync(Guid assetId);
        Task<AssignmentMdl> Add(AssignmentMdl assignmentMdl);
    }
}

