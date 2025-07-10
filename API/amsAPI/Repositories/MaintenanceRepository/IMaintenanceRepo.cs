using Domain.Models.MaintenanceModel;

namespace amsAPI.Repositories.MaintenanceRepository
{
    public interface IMaintenanceRepo
    {
       public Task<List<Maintenance>> GetAll();  

    }
}
