using amsAPI.Models.AssetModel;
using Domain.Models.AssetModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amsAPI.Repositories.AssetRepository
{
    public interface IAssetRepo
    {
        Task<bool> serialNumberExitsAsync(string serialNumber);
        Task<List<Asset>> GetAllAsync(AssetFilterParameters filtersParameters);
        Task<Asset> GetByIdAsync(Guid assetId);
        Task<Asset> Add(Asset asset);


    }
}
