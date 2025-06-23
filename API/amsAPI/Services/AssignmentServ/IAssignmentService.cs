using amsAPI.Models.AssignmentModel;

namespace amsAPI.Services.AssignmentServ
{
    public interface IAssignmentService
    {
        Task AssignAssetAsync(AssignAssetRequestDto request);
    }
}
