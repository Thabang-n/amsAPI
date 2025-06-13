using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.ReferenceData;

namespace amsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LookUpController : ControllerBase
    {
        private readonly ILookUpService _lookUpService;
        public LookUpController(ILookUpService lookUpService)
        {
           this._lookUpService = lookUpService; 
        }

        [HttpGet("/locations")]
        public async Task<IActionResult> GetAllLocationAsync()
        {
               var locations =  await _lookUpService.GetLocationsAsync();
            return Ok(locations);
        }

        [HttpGet("/brands")]
        public async Task<IActionResult> GetAllBrandsAsync()
        {
                var brands = await _lookUpService.GetBrandsAsync();
            return Ok(brands);
        }

        [HttpGet("/features")]
        public async Task<IActionResult> GetAllFeaturesAsync()
        {
            var features = await _lookUpService.GetFeaturesAsync();
            return Ok(features);
        }

        [HttpGet("/categories")]
        public async Task<IActionResult> GetAllCategoriesAsync()
        {
            var categories = await _lookUpService.GetCategoryAsync();
            return Ok(categories);
        }
    }
}
