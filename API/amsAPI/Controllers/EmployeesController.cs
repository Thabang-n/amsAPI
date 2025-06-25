using amsAPI.Services.EmployeeServ;
using Azure.Core;
using Domain.Models.EmployeeModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace amsAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeesController(IEmployeeService employeeService)
        {
           this._employeeService = employeeService; 
        }


        [Authorize]
[HttpGet("validate")]
    public async Task<IActionResult> ValidateTokenAndAddEmployee()
    {
        var authHeader = Request.Headers["Authorization"].FirstOrDefault();

        if (string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith("Bearer "))
            return Unauthorized("Missing or invalid Authorization header");

        var token = authHeader.Substring("Bearer ".Length).Trim();

        var handler = new JwtSecurityTokenHandler();
        JwtSecurityToken jwtToken;

        try
        {
            jwtToken = handler.ReadJwtToken(token);
        }
        catch
        {
            return BadRequest("Invalid JWT token");
        }
            var empIdString = jwtToken.Claims.FirstOrDefault(c => c.Type == "oid")?.Value;
            Guid employeeId = Guid.Parse(empIdString!);
            var email = jwtToken.Claims.FirstOrDefault(c => c.Type == "name")?.Value;
            var username = jwtToken.Claims.FirstOrDefault(c => c.Type == "unique_name")?.Value;

            await _employeeService.EnsureEmployeeExistsAsync(employeeId, email, username);

            return Ok(new { message = "successfully added" });
        }


    [HttpGet]
        public async Task<IActionResult> GetAllEmployeesAsync([FromQuery]string? search)
        {
            var result = await _employeeService.GetAllEmployeesAsync(search);
            return Ok(result);
        }
    }
}
