using Domain.Data;
using Domain.Models.MaintenanceModel;
using Microsoft.EntityFrameworkCore;

namespace amsAPI.Repositories.MaintenanceRepository
{
    public class MaintenanceRepo : IMaintenanceRepo
    {
        public amsDbContext _dbContext { get; }
        public MaintenanceRepo(amsDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<List<Maintenance>> GetAll()
        {
          return await _dbContext.Maintenances.Where( m => m.Status == "Pending")
                .Include(m => m.Employee)
                .Include(m => m.Asset)     
                .Include(m => m.Location)   
                .ToListAsync();
        }
    }
}
