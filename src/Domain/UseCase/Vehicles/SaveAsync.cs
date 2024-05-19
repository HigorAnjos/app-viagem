namespace Domain.UseCase.Vehicles
{
    public interface ISaveVehiclesAsync
    {
        public Task<Entities.Vehicle> SaveVehiclesAsync(Entities.Vehicle vehicles);
    }

    public class SaveAsync : ISaveVehiclesAsync
    {
        public Task<Entities.Vehicle> SaveVehiclesAsync(Entities.Vehicle vehicles)
        {
            throw new NotImplementedException();
        }
    }
}
