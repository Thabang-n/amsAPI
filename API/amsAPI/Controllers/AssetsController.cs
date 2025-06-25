using Domain.Models.AssetModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Assets;

namespace amsAPI.Controllers
{
    [Route("api/v1/")]
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

        [HttpGet("assets/")]
        public async Task<IActionResult> GetAssets(
        [FromQuery] string? search,
        [FromQuery] string? category,
        [FromQuery] string? country,
        [FromQuery] string? city,
        [FromQuery] string? status)
        {
            var assets = await _assetService.GetAllAssetsAsync(search, category, country, city, status);
            return Ok(new { assets });
        }

        [HttpGet("assets/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var asset = await _assetService.GetByIdAsync(id);

            if (asset == null)
                return NotFound();

            return Ok(asset);
        }
    }
}
