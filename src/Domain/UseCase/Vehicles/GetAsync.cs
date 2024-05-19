namespace Domain.UseCase.Vehicles
{
    public interface IGetVehiclesAsync
    {
        public Task<Entities.Vehicles> GetVehiclesAsync(long id);
    }

    public class GetAsync : IGetVehiclesAsync
    {
        public Task<Entities.Vehicles> GetVehiclesAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}
