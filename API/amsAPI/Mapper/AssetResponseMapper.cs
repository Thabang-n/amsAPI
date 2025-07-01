using amsAPI.Models.AssetAttributeModel;
using amsAPI.Models.AssetModel;
using Domain.Models.AssetModel;
using Domain.Models.BrandModel;
using Domain.Models.CategoryModel;
using Domain.Models.FeatureModel;
using Domain.Models.LocationModel;

namespace amsAPI.Mapper
{
    public class AssetResponseMapper
    {
        public static AssetResponseDto ConvertToDto(Asset asset)
        {
            return new AssetResponseDto
            {
                Id = asset.AssetId,
                SerialNumber = asset.SerialNumber,
                Description = asset.Description,
                DateCreated = asset.DateCreated,
                IsAssigned = asset.IsAssigned,
                Category = new CategoryDto
                {
                    CategoryId = asset.Category.CategoryId,
                    CategoryName = asset.Category.CategoryName
                },
                Location = new LocationDto
                {
                    LocationId = asset.Location.LocationId,
                    LocationName = asset.Location.LocationName,
                    LocationCity = asset.Location.LocationCity
                },
                Brand = new BrandDto
                {
                    BrandId = asset.Brand.BrandId,
                    BrandName = asset.Brand.BrandName
                },
                AssetAttributes = asset.AssetAttributes.Select(attr => new AssetAttributeResponseDto
                {
                    AssetAttributeId = attr.AssetAttributeId,
                    Value = attr.Value,
                    Feature = new FeatureDto
                    {
                        FeatureId = attr.Feature.FeatureId,
                        FeatureKey = attr.Feature.FeatureKey,
                        Category = new CategoryDto
                        {
                            CategoryId = attr.Feature.Category.CategoryId,
                            CategoryName = attr.Feature.Category.CategoryName
                        }
                    }
                }).ToList()
            };

        }
    }
}
