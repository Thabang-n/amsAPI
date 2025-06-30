using amsAPI.Services.ReferenceData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace amsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly BrandReferenceDataService _brandReferenceDataService;
        public BrandsController(BrandReferenceDataService brandReferenceDataService)
        {
          this._brandReferenceDataService = brandReferenceDataService; 
        }
        public async Task<IActionResult> GetAllBrands()
        {
            return Ok(await _brandReferenceDataService.GetAllBrands());
        }
    }
}
