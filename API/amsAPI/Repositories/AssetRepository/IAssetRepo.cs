using amsAPI.Models.AssetModel;
using amsAPI.Repositories.GenericRepository;
using Domain.Models.AssetModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amsAPI.Repositories.AssetRepository
{
    public interface IAssetRepo:IGenericRepo<Asset>
    {
        Task<bool> serialNumberExitsAsync(string serialNumber);
        Task<List<Asset>> GetAllAsync(AssetFilterParameters filtersParameters);
        Task<Asset> GetByIdAsync(Guid assetId);

    }
}
