using Domain.Repository;

namespace Domain.UseCase.Passenger
{
    public interface IGetPassengerAsync
    {
        public Task<Entities.Passenger> GetPassengerAsync(long id);
    }

    public class GetAsync : IGetPassengerAsync
    {
        private readonly IService _service;

        public GetAsync(IService service)
        {
            _service = service;
        }

        public async Task<Entities.Passenger> GetPassengerAsync(long id)
        {
            return await _service.GetPassengerAsync(id);
        }
    }
}
