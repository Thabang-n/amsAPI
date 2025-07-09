using amsAPI.mapper;
using Domain.Data;
using Domain.Models.CategoryModel;
using Microsoft.EntityFrameworkCore;

namespace amsAPI.Repositories.ReferenceDataRepository.CategoryRepository
{
    public class CategoryRepo : ICategoryRepo
    {
        public amsDbContext _dbcontext { get; }

        public CategoryRepo(amsDbContext dbContext)
        {
            _dbcontext = dbContext;
        }


        public async Task<List<Category>> GetAll()
        {
            return await _dbcontext.Categories.ToListAsync();

        }

        public async Task<Category> GetById(Guid id)
        {
            return await _dbcontext.Categories.FindAsync(id);
        }
    }
}
