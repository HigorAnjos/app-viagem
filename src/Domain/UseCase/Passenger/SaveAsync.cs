using Domain.Repository;

namespace Domain.UseCase.Passenger
{
    public interface ISavePassengerAsync
    {
        public Task<Domain.Entities.Passenger> SavePassengerAsync(Entities.Passenger passenger);
    }

    public class SaveAsync : ISavePassengerAsync
    {
        private readonly IService _service;

        public SaveAsync(IService service)
        {
            _service = service;
        }
        public async Task<Domain.Entities.Passenger> SavePassengerAsync(Entities.Passenger passenger)
        {
            return await _service.SavePassengerAsync(passenger);
        }
    }
}
