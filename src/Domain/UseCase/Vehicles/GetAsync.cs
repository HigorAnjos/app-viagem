using Domain.Repository;

namespace Domain.UseCase.Vehicles
{
    public interface IGetVehiclesAsync
    {
        public Task<Entities.Vehicle> GetVehiclesAsync(long id);
    }

    public class GetAsync : IGetVehiclesAsync
    {
        private readonly IService _service;

        public GetAsync(IService service)
        {
            _service = service;
        }

        public async Task<Entities.Vehicle> GetVehiclesAsync(long id)
        {
            return await _service.GetVehiclesAsync(id);
        }
    }
}
