using Domain.Data;
using Domain.Models.AssetAttributeModel;
using Domain.Models.AssetModel;
using Domain.Models.BrandModel;
using Domain.Models.CategoryModel;
using Domain.Models.FeatureModel;
using Domain.Models.LocationModel;
using Repositories.AssetRepository;
using Services.DbTransactionManager;
using Services.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Assets
{
    public class AssetService : IAssetService
    {
        
        private readonly IAssetRepo _assetReop;
        private readonly ITransactionService _transaction;
        private readonly IValidationService _validationService;



        public AssetService(IAssetRepo assetRepo, ITransactionService transaction,IValidationService validationService)
        {
          this._assetReop = assetRepo;
            this._transaction = transaction;
            this._validationService = validationService;
        }
        public async Task AddAssetAsync(AddAssetRequestDto requestDto)
        {
            var validationErrors = await _validationService.ValidateAddAssetRequestDto(requestDto);


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
                        FeatureId = Attr.FeatureId,
                        AssetAttributeValue =Attr.Value,


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
