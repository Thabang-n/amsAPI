using Domain.Models.LocationModel;

namespace amsAPI.Repositories.ReferenceDataRepository.LocationRepository
{
    public interface ILocationRepo
    {
        public Task<List<Location>> GetAllAsync();
        public Task<Location> GetById(Guid id);


    }
}
