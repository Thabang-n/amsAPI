using Domain.Data;
using Domain.Models.LocationModel;
using Microsoft.EntityFrameworkCore;

namespace amsAPI.Repositories.ReferenceData.LocationRepository
{
    public class LocationRepo : ILocationRepo
    {
        private readonly amsDbContext _amsDbContext;
        public LocationRepo(amsDbContext amsDbContext)
        {
            this._amsDbContext = amsDbContext;
        }
        public async Task<List<Location>> GetAll()
        {
            return await _amsDbContext.Locations.ToListAsync(); 
        }
    }
}
