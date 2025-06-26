using amsAPI.Models.AssetAttributeModel;
using amsAPI.Models.AssetModel;
using amsAPI.Repositories.AssetRepository;
using Domain.Models.AssetAttributeModel;
using Domain.Models.AssetModel;
using Domain.Models.AuditTrailModel;
using Domain.Models.BrandModel;
using Domain.Models.CategoryModel;
using Domain.Models.FeatureModel;
using Domain.Models.LocationModel;
using Services.DbTransactionManager;
using Services.Validations;

using System.ComponentModel.DataAnnotations;
using System.Security.Claims;


namespace Services.Assets
{
    public class AssetService : IAssetService
    {
        private readonly IAssetRepo _assetReop;
        private readonly ITransactionService _transaction;
       
        public AssetService(IAssetRepo assetRepo, ITransactionService transaction)
        {
            this._assetReop = assetRepo;
            this._transaction = transaction;
         


        }
        public async Task AddAssetAsync(AddAssetRequestDto requestDto)
        {
            
            var validator = new ValidateAddAssetRequestDto(_assetReop);
            var validationErrors = await validator.ValidateAsync(requestDto);


            if (validationErrors.Any())
                throw new ValidationException(string.Join("; ", validationErrors));

            await _transaction.BeginTransactionAsync();
            try
            {



                var assetId = Guid.NewGuid();

                var asset = new Asset
                {
                    AssetId = assetId,
                    CategoryId = requestDto.CategoryId,
                    LocationId = requestDto.LocationId,
                    IsAssigned = false,
                    Description = requestDto.Description,
                    BrandId = requestDto.BrandId,
                    DateCreated = DateTime.UtcNow,
                    SerialNumber = requestDto.SerialNumber,
                    AssetAttributes = requestDto.AssetAttributes.Select(Attr => new AssetAttribute
                    {
                        AssetAttributeId = Guid.NewGuid(),
                        AssetId = assetId,
                        FeatureId = Attr.FeatureId,
                        Value = Attr.Value



                    }).ToList() ?? new List<AssetAttribute>()


                };
                await _assetReop.AddAsync(asset);
                await _transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                {
                    await _transaction.RollbackAsync();
                    throw (ex);
                }
            }



        }
        public async Task<List<AssetResponseDtoV2>> GetAllAssetsAsync(AssetFilterParameters filtersParameters)
        {
            var assets = await _assetReop.GetAllAsync(filtersParameters);

            return assets.Select(a => new AssetResponseDtoV2
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
        public async Task<AssetResponseDtoV2> GetByIdAsync(Guid assetId)
        {
            var asset = await _assetReop.GetByIdAsync(assetId);

            if (asset == null)
                throw new Exception("Asset Not Found.");

            return new AssetResponseDtoV2
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
