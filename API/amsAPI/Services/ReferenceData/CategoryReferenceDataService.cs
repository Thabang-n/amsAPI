using amsAPI.Mapper;
using amsAPI.Repositories.ReferenceData.CategoryRepository;
using Domain.Models.CategoryModel;

namespace amsAPI.Services.ReferenceData
{
    public class CategoryReferenceDataService
    {
        private readonly ICategoryRepo _categoryRepo;
        public CategoryReferenceDataService(ICategoryRepo categoryRepo)
        {
         this._categoryRepo = categoryRepo;   
        }
        public async Task<List<CategoryDto>> GetAll()
        {
            return CategoriesResponseMapper.ConvertToDto(await _categoryRepo.GetAll());
        }


    }
}
