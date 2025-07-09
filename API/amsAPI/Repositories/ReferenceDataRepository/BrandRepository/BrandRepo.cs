using Domain.Data;
using Domain.Models.BrandModel;
using Microsoft.EntityFrameworkCore;

namespace amsAPI.Repositories.ReferenceDataRepository.BrandRepository
{
    public class BrandRepo : IBrandRepo
    {
        private amsDbContext _dbcontext { get; }
        public BrandRepo(amsDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }


        public async Task<List<Brand>> GetAll()
        {
            var brands = await _dbcontext.Brands.ToListAsync();
            return brands;
        }

        public async Task<Brand> GetById(Guid id)
        {
            var brand = await _dbcontext.Brands.FindAsync(id);
            return brand;
        }
    }
}
