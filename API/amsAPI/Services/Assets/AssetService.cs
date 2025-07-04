using amsAPI.Mapper;
using amsAPI.Models.AssetAttributeModel;
using amsAPI.Models.AssetModel;
using amsAPI.Repositories.AssetRepository;
using amsAPI.Validations;
using Domain.Models.AssetAttributeModel;
using Domain.Models.AssetModel;
using Domain.Models.AuditTrailModel;
using Domain.Models.BrandModel;
using Domain.Models.CategoryModel;
using Domain.Models.FeatureModel;
using Domain.Models.LocationModel;
using Services.DbTransactionManager;


using System.ComponentModel.DataAnnotations;
using System.Security.Claims;


namespace Services.Assets
{
    public class AssetService
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
                await _assetReop.Add(AssetRequestMapper.ConvertDtoToAsset(requestDto));
                await _transaction.CommitAsync();
            }
            catch
            {
                {
                    await _transaction.RollbackAsync();
                    throw;
                }
            }
        }
        public async Task<List<AssetResponseDto>> GetAllAssetsAsync(AssetFilterParameters filtersParameters)
        {
            return AssetResponseListMapper.ConvertToDtoList(await _assetReop.GetAllAsync(filtersParameters)); 
        }
        public async Task<AssetResponseDto> GetByIdAsync(Guid assetId)
        {
            return AssetResponseMapper.ConvertToDto(await _assetReop.GetByIdAsync(assetId));
        }
    }
    
    }
