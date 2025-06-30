using Domain.Models.BrandModel;

namespace amsAPI.Repositories.ReferenceData.BrandRepository
{
    public interface IBrandRepo
    {
        Task<List<Brand>> GetAll();
    }
}
