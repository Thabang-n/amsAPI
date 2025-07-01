using amsAPI.Services.ReferenceData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace amsAPI.Controllers
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly FeatureReferenceDataService _referenceDataService;

        public FeatureController(FeatureReferenceDataService referenceDataService)
        {
            _referenceDataService = referenceDataService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(Guid? id)
        {
            return Ok(await _referenceDataService.GetAll(id));
        }
    }
}
