using amsAPI.mapper;
using amsAPI.Mapper;
using amsAPI.Repositories.ReferenceData.BrandRepository;
using Domain.Models.BrandModel;

namespace amsAPI.Services.ReferenceData
{
    public class BrandReferenceDataService
    {
        private readonly IBrandRepo _brandRepo;
        
        public BrandReferenceDataService(IBrandRepo brandRepo, BrandResponseMapper brandResponseMapper)
        {
           this._brandRepo = brandRepo;
          
        }
        public async Task<List<BrandDto>> GetAllBrands()
        {
            return BrandResponseMapper.toDtoList(await _brandRepo.GetAll());
        }
    }
}
