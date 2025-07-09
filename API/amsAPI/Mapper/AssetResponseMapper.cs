using amsAPI.mapper;
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
        public static List<AssetResponseDto> getAssetDtoList(List<Asset> assets)
        {
            return assets.Select(a => new AssetResponseDto
            {
                Id = a.AssetId,
                SerialNumber = a.SerialNumber,
                Description = a.Description,
                DateCreated = a.DateCreated,
                IsAssigned = a.IsAssigned,
                Category = new CategoryDto
                {
                    CategoryId = a.Category.CategoryId,
                    CategoryName = a.Category.CategoryName
                },
                Location = new LocationDto
                {
                    LocationId = a.Location.LocationId,
                    LocationName = a.Location.LocationName,
                    LocationCity = a.Location.LocationCity
                },
                Brand = new BrandDto
                {
                    BrandId = a.Brand.BrandId,
                    BrandName = a.Brand.BrandName
                },
                AssetAttributes = a.AssetAttributes.Select(attr => new AssetAttributeResponseDto
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
            }).ToList();
        }


        public static AssetResponseDto getAssetDto(Asset asset)
        {
            return new AssetResponseDto
            {
                Id = asset.AssetId,
                SerialNumber = asset.SerialNumber,
                IsAssigned = asset.IsAssigned,
                Description = asset.Description,
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
