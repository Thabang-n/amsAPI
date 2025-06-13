using Domain.Models.AssetModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Validations
{
    public interface IValidationService
    {
        Task<List<string>> ValidateAddAssetRequestDto(AddAssetRequestDto addAssetRequestDto);
    }
}
