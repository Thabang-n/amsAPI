using Domain.Models.AssetAttributeModel;
using Domain.Models.AssetModel;

namespace amsAPI.Mapper
{
    public class AssetRequestMapper
    {
        public static Asset ConvertDtoToAsset(AddAssetRequestDto Dto)
        {
            var assetId = Guid.NewGuid();
            return new Asset
            {
                AssetId = assetId,
                CategoryId = Dto.CategoryId,
                LocationId = Dto.LocationId,
                BrandId = Dto.BrandId,
                SerialNumber = Dto.SerialNumber,
                DateCreated = new DateTime(),
                IsAssigned = false,
                Description = Dto.Description,
                IsDeleted = false,
                AssetAttributes = Dto.AssetAttributes.Select(attr => new AssetAttribute
                {
                    AssetAttributeId = Guid.NewGuid(),
                    AssetId = assetId,
                    FeatureId = attr.FeatureId,
                    Value = attr.Value
                }).ToList() ?? new List<AssetAttribute>()
            };
        }
    }
}

