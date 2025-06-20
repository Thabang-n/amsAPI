﻿using amsAPI.Repositories.GenericRepository;
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
    }
}
