using Domain.Models.AssetModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Assets
{
    public interface IAssetService
    {
        Task AddAssetAsync(AddAssetRequestDto requestDto);

    }
}
