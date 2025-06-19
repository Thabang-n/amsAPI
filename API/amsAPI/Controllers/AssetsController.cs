using Domain.Models.AssetModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Assets;

namespace amsAPI.Controllers
{
    [Route("api/V1/")]
    [ApiController]
    public class AssetsController : ControllerBase
    {
        private readonly IAssetService _assetService;
        public AssetsController(IAssetService assetService)
        {
           this._assetService = assetService; 
        }
        [HttpPost("assets")]
        public async Task<IActionResult> AddAssetAsync([FromBody] AddAssetRequestDto request)
        {
                await _assetService.AddAssetAsync(request);
            return Ok();

        }
    }
}
