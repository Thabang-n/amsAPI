using amsAPI.Repositories.AssetRepository;
using Domain.Models.AssetAttributeModel;
using Domain.Models.AssetModel;
using Services.DbTransactionManager;
using Services.Validations;

using System.ComponentModel.DataAnnotations;


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
                    SerialNumber = requestDto.SerialNumber,
                    AssetAttributes = requestDto.AssetAttributes.Select(Attr => new AssetAttribute
                    {
                        AssetAttributeId = Guid.NewGuid(),
                        AssetId = assetId,
                        FeatureId = Attr.FeatureId


                    }).ToList() ?? new List<AssetAttribute>()


                };
                await _assetReop.AddAsync(asset);
                await _transaction.CommitAsync();

               



            }
            catch
            {
                await _transaction.RollbackAsync();
                throw;
            }
        }
    }
}
