using amsAPI.Services.ReferenceData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace amsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly CategoryReferenceDataService _referenceDataService;
        public CategoriesController(CategoryReferenceDataService referenceDataService)
        {
           this._referenceDataService = referenceDataService; 
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _referenceDataService.GetAll());
        }
    }
}
