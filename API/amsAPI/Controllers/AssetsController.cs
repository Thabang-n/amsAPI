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
        private readonly IAssignmentService _assignmentService;
        public AssetsController(IAssignmentService assignmentService, AssetService assetService)
        {
            this._assetService = assetService;
            this._assignmentService = assignmentService;
            _assetService = assetService;
        }
        [HttpGet("assets/")]
        public async Task<IActionResult> GetAssets(
        [FromQuery] AssetFilterParameters filtersParameters)
        {
            return Ok(await _assetService.GetAllAssetsAsync(filtersParameters));
        }

        [HttpGet("assets/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _assetService.GetByIdAsync(id));
        }

        [HttpPost("assets")]
        public async Task<IActionResult> AddAssetAsync([FromBody] AddAssetRequestDto request)
        {
            await _assetService.AddAssetAsync(request);
            return Created();
        }
        [HttpPost("assignAsset")]
        public async Task<IActionResult> AssignAsseAsync(AssignAssetRequestDto request)
        {
            await _assignmentService.AssignAssetAsync(request);
            return Ok();
        }
    }
}
