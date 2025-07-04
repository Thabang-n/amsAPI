using Domain.Data;
using Domain.Models.CategoryModel;
using Microsoft.EntityFrameworkCore;

namespace amsAPI.Repositories.ReferenceData.CategoryRepository
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly amsDbContext _amsDbContext;
        public CategoryRepo(amsDbContext amsDbContext)
        {
          this._amsDbContext = amsDbContext;  
        }
        public async Task<List<Category>> GetAll()
        {
            return await _amsDbContext.Categories.ToListAsync();
        }
    }
}
