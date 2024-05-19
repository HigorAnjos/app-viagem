namespace Domain.UseCase.Vehicles
{
    public interface ISaveVehiclesAsync
    {
        public Task<Entities.Vehicles> SaveVehiclesAsync(Entities.Vehicles vehicles);
    }

    public class SaveAsync : ISaveVehiclesAsync
    {
        public Task<Entities.Vehicles> SaveVehiclesAsync(Entities.Vehicles vehicles)
        {
            throw new NotImplementedException();
        }
    }
}
