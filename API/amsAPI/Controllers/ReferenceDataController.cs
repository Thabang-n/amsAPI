
using amsAPI.Helpers;
using amsAPI.Services.ReferenceDataServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace amsAPI.Controllers
{
    [Route("api/v1/")]
    [ApiController]
    public class ReferenceDataController : ControllerBase
    {
        private readonly LocationService _locationService;
        private readonly CategoryService _categoryService;
        private readonly BrandService _brandService;
        private readonly FeatureService _featureService;


        public ReferenceDataController( LocationService locationService, CategoryService categoryService, BrandService brandService,FeatureService featureService)
        {
            _locationService = locationService;
            _categoryService = categoryService;
            _brandService = brandService;
            _featureService = featureService;
            
        }

        [HttpGet("locations")]
        public async Task<IActionResult> GetAllLocations()
        {
            return Ok(await _locationService.GetLocations()); 
        }

        [HttpGet("categories")]
        public async Task<IActionResult> GetAllCategoriesAsync()
        {
         var categories = (await _categoryService.GetAllCategories());

            var successResponse = new ApiResponse.Builder()
                .setSuccess(true)
                .setMessage("Category retrieved successfully")
                .setdata(categories).setStatusCode(200)
                .build();

            return Ok(successResponse);
            
        }

        [HttpGet("brands")]
        public async Task<IActionResult> GetAllBrandsAsync()
        {
            return Ok(await _brandService.GetAllBrands());
        }

        [HttpGet("features/{id}")]
        public async Task<IActionResult> GetAllFeaturesAsync([FromRoute] Guid id)
        {
            return Ok(await _featureService.GetAllFeatures(id));
        }


    }
}
