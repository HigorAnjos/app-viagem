using Domain.Repository;

namespace Domain.UseCase.Trip
{
    public interface ISaveTripAsync
    {
        public Task<Entities.Trip> SaveTripAsync(Entities.Trip trip);
    }

    public class SaveAsync : ISaveTripAsync
    {
        private readonly IService _service;

        public SaveAsync(IService service)
        {
            _service = service;
        }

        public async Task<Entities.Trip> SaveTripAsync(Entities.Trip trip)
        {
            return await _service.SaveTripAsync(trip);
        }
    }
}
