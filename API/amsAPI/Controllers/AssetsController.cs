using amsAPI.Models.AssetModel;
using amsAPI.Models.AssignmentModel;
using amsAPI.Services.AssignmentServ;
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
        private readonly AssetService _assetService;
        private readonly AssignmentService _assignmentService;
        public AssetsController(AssetService assetService, AssignmentService assignmentService)
        {
           _assetService = assetService;
           _assignmentService = assignmentService;
        }
        [HttpGet("assets/")]
        public async Task<IActionResult> GetAssets(
        [FromQuery] AssetFilterParameters filtersParameters)
        {
            var assets = await _assetService.GetAllAssetsAsync(filtersParameters);
            return Ok(new { assets });
        }

        [HttpGet("assets/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var asset = await _assetService.GetAssetByIdAsync(id);

            if (asset == null)
                return NotFound();

            return Ok(asset);
        }

        [HttpPost("assets")]
        public async Task<IActionResult> AddAssetAsync([FromBody] AddAssetRequestDto request)
        {
                await _assetService.AddAssetAsync(request);
            return Ok();

        }
        [HttpPost("assignAsset")]
        public async Task<IActionResult> AssignAsseAsync(AssignAssetRequestDto request)
        {
            await _assignmentService.AssignAssetAsync(request);
            return Ok();
        }
    }
}
