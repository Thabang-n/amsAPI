using amsAPI.Services.EmployeeServ;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace amsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeesController(IEmployeeService employeeService)
        {
           this._employeeService = employeeService; 
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployeesAsync([FromQuery]string? search)
        {
            var result = await _employeeService.GetAllEmployeesAsync(search);
            return Ok(result);
        }
    }
}
