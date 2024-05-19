namespace Domain.UseCase.Passenger
{
    public interface ISavePassengerAsync
    {
        public Task<Domain.Entities.Passenger> SavePassengerAsync(Entities.Passenger passenger);
    }

    public class SaveAsync : ISavePassengerAsync
    {
        public Task<Domain.Entities.Passenger> SavePassengerAsync(Entities.Passenger passenger)
        {
            throw new NotImplementedException();
        }
    }
}
