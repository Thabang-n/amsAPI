using amsAPI.Models.AssetModel;
using Domain.Data;
using Domain.Models.AssetModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amsAPI.Repositories.AssetRepository
{
    public class AssetRepo:IAssetRepo
    {
        private readonly amsDbContext _dbcontext;

        public AssetRepo(amsDbContext context)
        {
            _dbcontext = context;  
        }
        public Task<bool> serialNumberExitsAsync(string serialNumber)
        {
            return _dbcontext.Assets.AnyAsync(asset => asset.SerialNumber == serialNumber);
        }

        public async Task<List<Asset>> GetAllAsync(AssetFilterParameters filtersParameters)
        {
            IQueryable<Asset> query = _dbcontext.Assets
                .Include(a => a.Category)
                .Include(a => a.Location)
                .Include(a => a.Brand)
                .Include(a => a.AssetAttributes)
                    .ThenInclude(attr => attr.Feature);
         
            query = FilterAssetResponse.ApplyFiltering(query,filtersParameters);
            query = SortAssetResponse.SortAsset(query, filtersParameters);

            var skipResults = (filtersParameters.pageNumber - 1) * filtersParameters.pageSize;
            return await query.Skip(skipResults).Take(filtersParameters.pageSize).ToListAsync();
        }

        public async Task<Asset> GetByIdAsync(Guid assetId)
        {
            return await _dbcontext.Assets
           .Include(a => a.Category)
           .Include(a => a.Location)
           .Include(a => a.Brand)
           .Include(a => a.AssetAttributes)
               .ThenInclude(attr => attr.Feature)
           .FirstOrDefaultAsync(a => a.AssetId == assetId);

        }

        public async Task<Asset> AddAsync(Asset asset)
        {
            await _dbcontext.Assets.AddAsync(asset);
            await _dbcontext.SaveChangesAsync();
            return asset;

        }
    }
}

