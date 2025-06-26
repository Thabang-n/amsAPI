using amsAPI.Models.AssetModel;
using amsAPI.Repositories.GenericRepository;
using Domain.Data;
using Domain.Models.AssetModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amsAPI.Repositories.AssetRepository
{
    public class AssetRepo : GenericRepo<Asset>,IAssetRepo
    {
        private readonly amsDbContext _context;

        public AssetRepo(amsDbContext context):base(context)
        {
            _context = context;  
        }

     

        public Task<bool> serialNumberExitsAsync(string serialNumber)
        {
            return _context.Assets.AnyAsync(asset => asset.SerialNumber == serialNumber);
        }
        public async Task<List<Asset>> GetAllAsync(AssetFilterParameters filtersParameters)
        {
            var query = _context.Assets
                .Include(a => a.Category)
                .Include(a => a.Location)
                .Include(a => a.Brand)
                .Include(a => a.AssetAttributes)
                    .ThenInclude(attr => attr.Feature)
                .AsQueryable();

            
            if (!string.IsNullOrEmpty(filtersParameters.filterOn) && !string.IsNullOrWhiteSpace(filtersParameters.filterQuery))
            {
                var filterOn = filtersParameters.filterOn;
                var filterQuery = filtersParameters.filterQuery;

                if (filterOn.Equals("Category", StringComparison.OrdinalIgnoreCase))
                {
                    query = query.Where(x => x.Category.CategoryName.Contains(filterQuery));
                }
                else if (filterOn.Equals("Country", StringComparison.OrdinalIgnoreCase))
                {
                    query = query.Where(x => x.Location.LocationName.Contains(filterQuery));
                }
                else if (filterOn.Equals("City", StringComparison.OrdinalIgnoreCase))
                {
                    query = query.Where(x => x.Location.LocationCity.Contains(filterQuery));
                }
                else if (filterOn.Equals("Status", StringComparison.OrdinalIgnoreCase))
                {
                    bool isAssigned = filterQuery.Equals("Assigned", StringComparison.OrdinalIgnoreCase);
                    query = query.Where(x => x.IsAssigned == isAssigned);
                }
                else if (filterOn.Equals("Search", StringComparison.OrdinalIgnoreCase))
                {
                    query = query.Where(x =>
                        x.SerialNumber.Contains(filterQuery) ||
                        x.Description.Contains(filterQuery) ||
                        x.Category.CategoryName.Contains(filterQuery) ||
                        x.Location.LocationName.Contains(filterQuery) ||
                        x.Brand.BrandName.Contains(filterQuery));
                }
            }

            if (!string.IsNullOrWhiteSpace(filtersParameters.SortBy))
            {
                var sortBy = filtersParameters.SortBy;
                var isAscending = filtersParameters.isAscending;

                if (sortBy.Equals("DateCreated", StringComparison.OrdinalIgnoreCase))
                {
                    query = isAscending
                        ? query.OrderBy(a => a.DateCreated)
                        : query.OrderByDescending(a => a.DateCreated);
                }
                else if (sortBy.Equals("Status", StringComparison.OrdinalIgnoreCase))
                {
                    query = isAscending
                        ? query.OrderBy(a => a.IsAssigned)
                        : query.OrderByDescending(a => a.IsAssigned);
                }
            }

            var skipResults = (filtersParameters.pageNumber - 1) * filtersParameters.pageSize;
            return await query.Skip(skipResults).Take(filtersParameters.pageSize).ToListAsync();
        }

        public async Task<Asset> GetByIdAsync(Guid assetId)
        {
            
                return await _context.Assets
               .Include(a => a.Category)
               .Include(a => a.Location)
               .Include(a => a.Brand)
               .Include(a => a.AssetAttributes)
                   .ThenInclude(attr => attr.Feature)
               .FirstOrDefaultAsync(a => a.AssetId == assetId);
           
        }

    }
}
