using amsAPI.Repositories.GenericRepository;
using Domain.Data;
using Domain.Models.AssetModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public async Task<List<Asset>> GetAllAsync(
            string? search = null,
            string? category = null,
            string? country = null,
            string? city = null,
            string? status = null)
        {
            var query = _context.Assets
                .Include(a => a.Category)
                .Include(a => a.Location)
                .Include(a => a.Brand)
                .Include(a => a.AssetAttributes)
                    .ThenInclude(attr => attr.Feature)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(a =>
                    a.SerialNumber.Contains(search) ||
                    a.Description.Contains(search));
            }

            if (!string.IsNullOrWhiteSpace(category))
            {
                query = query.Where(a => a.Category.CategoryName == category);
            }

            if (!string.IsNullOrWhiteSpace(country))
            {
                query = query.Where(a => a.Location.LocationName == country);
            }

            if (!string.IsNullOrWhiteSpace(city))
            {
                query = query.Where(a => a.Location.LocationCity == city);
            }

            if (!string.IsNullOrWhiteSpace(status))
            {
                if (status.Equals("Assigned", StringComparison.OrdinalIgnoreCase))
                    query = query.Where(a => a.IsAssigned == true);
                else if (status.Equals("Unassigned", StringComparison.OrdinalIgnoreCase))
                    query = query.Where(a => a.IsAssigned == false);
            }

            return await query.ToListAsync();
        }

        public async Task<Asset> GetByIdAsync(Guid assetId)
        {
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
}
