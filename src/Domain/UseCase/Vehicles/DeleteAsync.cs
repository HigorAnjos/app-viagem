namespace Domain.UseCase.Vehicles
{
    public interface IDeleteVehiclesAsync
    {
        public Task<bool> DeleteVehiclesAsync(long id);
    }

    public class DeleteAsync : IDeleteVehiclesAsync
    {
        public Task<bool> DeleteVehiclesAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}
