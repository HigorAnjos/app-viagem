
using Domain.Repository;

namespace Domain.UseCase.Trip
{
    public interface IGetTripAsync
    {
        public Task<Entities.Trip> GetTripAsync(long id);
        public Task<IEnumerable<Entities.Trip>> GetAllTripAsync();
    }

    public class GetAsync : IGetTripAsync
    {
        private readonly IService _service;

        public GetAsync(IService service)
        {
            _service = service;
        }

        public async Task<IEnumerable<Entities.Trip>> GetAllTripAsync()
        {
            return await _service.GetAllTripAsync();
        }

        public async Task<Entities.Trip> GetTripAsync(long id)
        {
            return await _service.GetTripAsync(id);
        }
    }
}
