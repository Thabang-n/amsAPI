using amsAPI.Mapper;
using amsAPI.Models.AssetModel;
using amsAPI.Repositories.AssetRepository;
using Domain.Models.AssetModel;
using Services.DbTransactionManager;
using Services.Validations;
using System.ComponentModel.DataAnnotations;


namespace Services.Assets
{
    public class AssetService 
    {
        private readonly IAssetRepo _assetRepo;
        private readonly ITransactionService _transaction;
       
        public AssetService(IAssetRepo assetRepo, ITransactionService transaction)
        {
            _assetRepo = assetRepo;
            _transaction = transaction;
        }

        public async Task AddAssetAsync(AddAssetRequestDto AddAssetDto)
        {
            var validator = new ValidateAddAssetRequestDto(_assetRepo);
            var validationErrors = await validator.ValidateAsync(AddAssetDto);

            if (validationErrors.Any())
                throw new ValidationException(string.Join("; ", validationErrors));

            await _transaction.BeginTransactionAsync();
            try
            {
                var asset = AssetRequestMapper.MapAsset(AddAssetDto);
                await _assetRepo.AddAsync(asset);
                await _transaction.CommitAsync();
            }
            catch (Exception ex)
            {
              await _transaction.RollbackAsync();
              throw(ex);
                
            }
        }

        public async Task<List<AssetResponseDto>> GetAllAssetsAsync(AssetFilterParameters filtersParameters)
        {
            var assets = await _assetRepo.GetAllAsync(filtersParameters);
            return AssetResponseMapper.getAssetDtoList(assets);
        }

        public async Task<AssetResponseDto> GetAssetByIdAsync(Guid assetId)
        {
            var asset = await _assetRepo.GetByIdAsync(assetId);
            if (asset == null)
                throw new Exception("Asset Not Found.");
            return AssetResponseMapper.getAssetDto(asset);
        }
    }
    
}
