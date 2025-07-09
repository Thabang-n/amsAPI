using amsAPI.Mapper;
using amsAPI.Repositories.ReferenceDataRepository.BrandRepository;
using Domain.Models.BrandModel;

namespace amsAPI.Services.ReferenceDataServices
{
    public class BrandService
    {
        private IBrandRepo _brandRepo { get; }
        public BrandService(IBrandRepo brandRepo)
        {
            _brandRepo = brandRepo;
        }


        public async  Task<List<BrandDto>> GetAllBrands()
        {
            var brand = await _brandRepo.GetAll();
            return BrandResponseMapper.ToListDto(brand);

            //return BrandResponseMapper.ToListDto(await _brandRepo.GetAll());
        }

       
    }
}
