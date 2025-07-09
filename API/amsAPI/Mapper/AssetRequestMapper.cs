using Domain.Models.AssetAttributeModel;
using Domain.Models.AssetModel;

namespace amsAPI.Mapper
{
    public class AssetRequestMapper
    {

        public static Asset MapAsset( AddAssetRequestDto assetDto)
        {
           var assetId = Guid.NewGuid();
           return new Asset()
           {
            AssetId = assetId,
            CategoryId = assetDto.CategoryId,
            LocationId = assetDto.LocationId,
            IsAssigned = false,
            Description = assetDto.Description,
            BrandId = assetDto.BrandId,
            DateCreated = DateTime.UtcNow,
            SerialNumber = assetDto.SerialNumber,
            AssetAttributes = assetDto.AssetAttributes.Select(Attr => new AssetAttribute
            {
                AssetAttributeId = Guid.NewGuid(),
                AssetId = assetId,
                FeatureId = Attr.FeatureId,
                Value = Attr.Value

            }).ToList() ?? new List<AssetAttribute>()

        };

        }
    }
}
