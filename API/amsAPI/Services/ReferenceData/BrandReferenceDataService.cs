using amsAPI.Repositories.ReferenceData.BrandRepository;
using Domain.Models.BrandModel;

namespace amsAPI.Services.ReferenceData
{
    public class BrandReferenceDataService
    {
        private readonly IBrandRepo _brandRepo;
        public BrandReferenceDataService(IBrandRepo brandRepo)
        {
           this._brandRepo = brandRepo; 
        }
        public async Task<List<Brand>> GetAllBrands()
        {
            return await _brandRepo.GetAll();
        }
    }
}
