using Domain.Models.CategoryModel;

namespace amsAPI.Repositories.ReferenceDataRepository.CategoryRepository
{
    public interface ICategoryRepo
    {
        public Task<List<Category>> GetAll();
        public Task<Category> GetById(Guid id);
    }
}
