using Domain.Models.BrandModel;

namespace amsAPI.Repositories.ReferenceDataRepository.BrandRepository
{
    public interface IBrandRepo
    {
        public Task<List<Brand>> GetAll();
        public Task<Brand> GetById(Guid id);
    }
}
