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
        private readonly IAssetService _assetService;
        private readonly IAssignmentService _assignmentService;
        public AssetsController(IAssetService assetService, IAssignmentService assignmentService)
        {
           this._assetService = assetService;
            this._assignmentService = assignmentService;
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
