using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.ReferenceData;

namespace amsAPI.Controllers
{
    [Route("api/v1/")]
    [ApiController]
    public class ReferenceDataController : ControllerBase
    {
        private readonly IReferenceDataService _referenceDataService;
        public ReferenceDataController(IReferenceDataService referenceDataService)
        {
           this._referenceDataService = referenceDataService; 
        }

        [HttpGet("locations")]
        public async Task<IActionResult> GetAllLocationAsync()
        {
               var locations =  await _referenceDataService.GetLocationsAsync();
            return Ok(locations);
        }

        [HttpGet("brands")]
        public async Task<IActionResult> GetAllBrandsAsync()
        {
                var brands = await _referenceDataService.GetBrandsAsync();
            return Ok(brands);
        }

        [HttpGet("features")]
        public async Task<IActionResult> GetAllFeaturesAsync(Guid id)
        {
            var features = await _referenceDataService.GetFeaturesAsync(id);
            return Ok(features);
        }

        [HttpGet("categories")]
        public async Task<IActionResult> GetAllCategoriesAsync()
        {
            var categories = await _referenceDataService.GetCategoryAsync();
            return Ok(categories);
        }
    }
}
