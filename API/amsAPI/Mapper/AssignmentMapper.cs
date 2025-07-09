using amsAPI.Models.AssignmentModel;
using Azure.Core;

namespace amsAPI.Mapper
{
    public class AssignmentMapper
    {
        public static Assignment MapAssignment(AssignAssetRequestDto assignAsset)
        {
           return new Assignment
            {
                AssetId = assignAsset.AssetId,
                AdminId = assignAsset.AdminId,
                EmployeeId = assignAsset.EmployeeId,
                AssignedDate = DateTime.Now,
                IsLinked = true
            };

        }
    }
}
