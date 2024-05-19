namespace Domain.UseCase.Passenger
{
    public interface IGetPassengerAsync
    {
        public Task<Entities.Passenger> GetPassengerAsync(long id);
    }

    public class GetAsync : IGetPassengerAsync
    {
        public Task<Entities.Passenger> GetPassengerAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}
