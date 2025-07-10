using amsAPI.Services.Maintenance;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace amsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaintenanceController : ControllerBase
    {
        public MaintenanceService _maintenanceService { get; }
        public MaintenanceController(MaintenanceService maintenanceService)
        {
            _maintenanceService = maintenanceService;
        }


        [HttpGet]
        public async Task<IActionResult> GetPendingMaintenanceRequests()
        {
            return Ok( await _maintenanceService.GetAllPendingMaintenanceRequests()); 
        }
    }
}
