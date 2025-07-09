using amsAPI.mapper;
using amsAPI.Repositories.ReferenceDataRepository.CategoryRepository;
using Domain.Models.CategoryModel;

namespace amsAPI.Services.ReferenceDataServices
{
    public class CategoryService
    {
        private readonly ICategoryRepo _Category;
        public CategoryService(ICategoryRepo categoryRepo)
        {
           _Category = categoryRepo;
        }


        public async Task<List<CategoryDto>> GetAllCategories()
        {
            var categories = await _Category.GetAll();
            return CategoryResponseMapper.ListToDto(categories);

            //return CategoryResponseMapper.ListToDto(await _Category.GetAll());
        }
    }
}
