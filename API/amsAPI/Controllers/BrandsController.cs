using amsAPI.Services.ReferenceData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace amsAPI.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly BrandReferenceDataService _brandReferenceDataService;
        public BrandsController(BrandReferenceDataService brandReferenceDataService)
        {
          this._brandReferenceDataService = brandReferenceDataService; 
        }
        [HttpGet("brands")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _brandReferenceDataService.GetAllBrands());
        }
    }
}
