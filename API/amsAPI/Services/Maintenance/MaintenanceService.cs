using amsAPI.Mapper;
using amsAPI.Models.MaintenanceModel;
using amsAPI.Repositories.MaintenanceRepository;

namespace amsAPI.Services.Maintenance
{
    public class MaintenanceService
    {
        public IMaintenanceRepo _maintenanceRepo { get; }
        public MaintenanceService(IMaintenanceRepo maintenanceRepo)
        {
            _maintenanceRepo = maintenanceRepo;
        }


        public async Task<List<ResponseMaintenanceDto>> GetAllPendingMaintenanceRequests()
        {
          return MaintenanceResponseMapper.MapToDto( await _maintenanceRepo.GetAll());

        }
    }
}
