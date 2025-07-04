using Domain.Models.LocationModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.ReferenceData;

namespace amsAPI.Controllers
{
    [Route("api/v1/")]
    [ApiController]
    public class LocationController : ControllerBase
    {
      private readonly LocationReferenceDataService _locationReferenceDataService;
        public LocationController(LocationReferenceDataService locationReferenceDataService)
        {
           _locationReferenceDataService = locationReferenceDataService; 
        }
        [HttpGet("Locations")]
        public async Task<IActionResult> GetAllLocations()
        {
           return Ok(await _locationReferenceDataService.GetLocations());
        }
    }
}
