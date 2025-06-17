using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.ReferenceData;

namespace amsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReferenceDataController : ControllerBase
    {
        private readonly IReferenceDataService _referenceDataService;
        public ReferenceDataController(IReferenceDataService lookUpService)
        {
           this._referenceDataService = lookUpService; 
        }

        [HttpGet("/locations")]
        public async Task<IActionResult> GetAllLocationAsync()
        {
               var locations =  await _referenceDataService.GetLocationsAsync();
            return Ok(locations);
        }

        [HttpGet("/brands")]
        public async Task<IActionResult> GetAllBrandsAsync()
        {
                var brands = await _referenceDataService.GetBrandsAsync();
            return Ok(brands);
        }

        [HttpGet("/features")]
        public async Task<IActionResult> GetAllFeaturesAsync()
        {
            var features = await _referenceDataService.GetFeaturesAsync();
            return Ok(features);
        }

        [HttpGet("/categories")]
        public async Task<IActionResult> GetAllCategoriesAsync()
        {
            var categories = await _referenceDataService.GetCategoryAsync();
            return Ok(categories);
        }
    }
}
