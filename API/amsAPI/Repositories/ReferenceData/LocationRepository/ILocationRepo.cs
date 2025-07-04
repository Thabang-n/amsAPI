using Domain.Models.LocationModel;

namespace amsAPI.Repositories.ReferenceData.LocationRepository
{
    public interface ILocationRepo
    {
        Task<List<Location>> GetAll();
    }
}
