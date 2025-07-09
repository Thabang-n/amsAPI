using Domain.Data;
using Domain.Models.LocationModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace amsAPI.Repositories.ReferenceDataRepository.LocationRepository
{
    public class LocationRepo : ILocationRepo
    {

        public amsDbContext _dbcontext { get; }

        public LocationRepo(amsDbContext dbContext)
        {
            _dbcontext = dbContext;
        }


        public async Task<Location> GetById(Guid id)
        {
            return await _dbcontext.Locations.FindAsync(id);
        }

        public async Task<List<Location>> GetAllAsync()
        {
            return await _dbcontext.Locations.ToListAsync();
        }


    }
}
