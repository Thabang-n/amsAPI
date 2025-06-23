using Domain.Models.BrandModel;
using Domain.Models.CategoryModel;
using Domain.Models.FeatureModel;
using Domain.Models.LocationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ReferenceData
{
    public interface IReferenceDataService
    {
        Task<List<BrandDto>> GetBrandsAsync();
        Task<List<LocationDto>> GetLocationsAsync();
        Task<List<FeatureDto>> GetFeaturesAsync(Guid categoryId);
        Task<List<CategoryDto>> GetCategoryAsync();


    }
}
