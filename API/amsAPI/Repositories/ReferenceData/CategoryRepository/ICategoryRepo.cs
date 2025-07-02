using Domain.Models.CategoryModel;

namespace amsAPI.Repositories.ReferenceData.CategoryRepository
{
    public interface ICategoryRepo
    {
        Task<List<Category>> GetAll();
    }
}
