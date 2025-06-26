using amsAPI.Repositories.AssetRepository;
using Domain.Models.AssetModel;


namespace amsAPI.Validations
{
    public class ValidateAddAssetRequestDto
    {
        private readonly IAssetRepo _assetRepo;
        
        public ValidateAddAssetRequestDto(IAssetRepo assetRepo)
        {
          _assetRepo = assetRepo;  
        }
        public async Task<List<string>> ValidateAsync(AddAssetRequestDto dto)
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
                }
            }

            return errors;
        }


    }
    
}
