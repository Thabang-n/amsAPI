using Domain.Models.AssetModel;
using Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.AssetRepository
{
    public interface IAssetRepo:IGenericRepo<Asset>
    {
        Task<bool> serialNumberExitsAsync(string serialNumber);
    }
}
