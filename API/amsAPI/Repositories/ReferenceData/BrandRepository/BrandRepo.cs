using Domain.Data;
using Domain.Models.BrandModel;
using Microsoft.EntityFrameworkCore;

namespace amsAPI.Repositories.ReferenceData.BrandRepository
{
    public class BrandRepo : IBrandRepo
    {
        private readonly amsDbContext _amsDbContext;
        public BrandRepo(amsDbContext amsDbContext)
        {
          this._amsDbContext = amsDbContext;  
        }
        public async Task<List<Brand>> GetAll()
        {
            return await _amsDbContext.Brands.ToListAsync();
        }
    }
}
