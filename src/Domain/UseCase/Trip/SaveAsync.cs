namespace Domain.UseCase.Trip
{
    public interface ISaveTripAsync
    {
        public Task<Entities.Trip> SaveTripAsync(Entities.Trip trip);
    }

    public class SaveAsync : ISaveTripAsync
    {
        public Task<Entities.Trip> SaveTripAsync(Entities.Trip trip)
        {
            throw new NotImplementedException();
        }
    }
}
