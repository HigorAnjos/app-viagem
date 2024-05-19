using Domain.Repository;

namespace Domain.UseCase.Vehicles
{
    public interface ISaveVehiclesAsync
    {
        public Task<Entities.Vehicle> SaveVehiclesAsync(Entities.Vehicle vehicles);
    }

    public class SaveAsync : ISaveVehiclesAsync
    {
        private readonly IService _service;

        public SaveAsync(IService service)
        {
            _service = service;
        }

        public async Task<Entities.Vehicle> SaveVehiclesAsync(Entities.Vehicle vehicles)
        {
            return await _service.SaveVehiclesAsync(vehicles);
        }
    }
}
