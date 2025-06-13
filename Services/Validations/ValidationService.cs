using Domain.Models.AssetModel;
using Microsoft.IdentityModel.Tokens;
using Repositories.AssetRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Validations
{
    public class ValidationService : IValidationService
    {
        private readonly IAssetRepo _assetRepo;
        public ValidationService(IAssetRepo assetRepo)
        {
          this._assetRepo = assetRepo;  
        }
        public async Task<List<string>> ValidateAddAssetRequestDto(AddAssetRequestDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto), "Request cannot be null");

            var errors = new List<string>();

            if (dto.CategoryId == Guid.Empty)
                errors.Add("CategoryId is required.");

            if (dto.LocationId == Guid.Empty)
                errors.Add("LocationId is required.");

            if (dto.BrandId == Guid.Empty)
                errors.Add("BrandId is required.");


            if (string.IsNullOrWhiteSpace(dto.SerialNumber))
            {
                errors.Add("SerialNumber is required.");
            }
            else
            {
                bool serialExists = await _assetRepo.serialNumberExitsAsync(dto.SerialNumber);
                if (serialExists)
                    errors.Add("Serial number already exists.");
            }

            if (dto.AssetAttributes == null || dto.AssetAttributes.Count == 0)
            {
                errors.Add("At least one AssetAttribute is required.");
            }
            else
            {
                foreach (var attr in dto.AssetAttributes)
                {
                    if (attr.FeatureId == Guid.Empty)
                        errors.Add("Each AssetAttribute must have a valid FeatureId.");

                    if (string.IsNullOrWhiteSpace(attr.Value))
                        errors.Add("Each AssetAttribute must have a non-empty Value.");
                }
            }

            return errors;
        }


    }
    
}
