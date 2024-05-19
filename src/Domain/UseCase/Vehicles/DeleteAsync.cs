using Domain.Repository;

namespace Domain.UseCase.Vehicles
{
    public interface IDeleteVehiclesAsync
    {
        public Task<bool> DeleteVehiclesAsync(long id);
    }

    public class DeleteAsync : IDeleteVehiclesAsync
    {
        private readonly IService _service;

        public DeleteAsync(IService service)
        {
            _service = service;
        }

        public async Task<bool> DeleteVehiclesAsync(long id)
        {
            return await _service.DeleteVehiclesAsync(id);
        }
    }
}
