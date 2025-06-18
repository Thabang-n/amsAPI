using amsAPI.Repositories.GenericRepository;
using Domain.Data;
using Domain.Models.BrandModel;
using Domain.Models.CategoryModel;
using Domain.Models.FeatureModel;
using Domain.Models.LocationModel;
using Microsoft.EntityFrameworkCore;


namespace Services.ReferenceData
{
    public class ReferenceDataService : IReferenceDataService
    {
        private readonly IGenericRepo<Brand> _brandRepo;
        private readonly IGenericRepo<LocationDto> _locationRepo;
        private IGenericRepo<Category> _categoryRepo;
        private readonly amsDbContext _context;

        public ReferenceDataService(IGenericRepo<Brand> brandRepo,IGenericRepo<LocationDto> locationRepo,IGenericRepo<Feature> featureRepo, IGenericRepo<Category> categoryRepo, amsDbContext context)
        {
            _brandRepo = brandRepo;
            _locationRepo = locationRepo;
            _categoryRepo = categoryRepo;
            _context = context;
        }

        public async Task<List<CategoryDto>> GetCategoryAsync()
        {
            var categories = await _categoryRepo.GetAllAsync();

            var categoryDtos = categories.Select(category => new CategoryDto
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName
            }).ToList();

            return categoryDtos;
        }

        public async Task<List<FeatureDto>> GetFeaturesAsync()
        {
            var features = await _context.Features
                .Include(feature => feature.Category)
                .ToListAsync();

            var featureDtos = features.Select(feature => new FeatureDto
            {
                FeatureId = feature.FeatureId,
                FeatureKey = feature.FeatureKey,
                Category = new CategoryDto
                {
                    CategoryId = feature.Category.CategoryId,
                    CategoryName = feature.Category.CategoryName
                }
            }).ToList();

            return featureDtos;
        }

        async Task<List<BrandDto>> IReferenceDataService.GetBrandsAsync()
        {
            var brands = await _brandRepo.GetAllAsync();

            var brandDto = brands.Select(brand => new BrandDto
            {
                BrandId = brand.BrandId,
                BrandName = brand.BrandName,

            }).ToList();

            return brandDto;
        }

        async Task<List<LocationDto>> IReferenceDataService.GetLocationsAsync()
        {
            var locations = await _locationRepo.GetAllAsync();

            var locationDtos = locations.Select(location => new LocationDto
            {
                LocationId = location.LocationId,
                LocationCity = location.LocationCity
            }).ToList();

            return locationDtos;
        }
    }
}
