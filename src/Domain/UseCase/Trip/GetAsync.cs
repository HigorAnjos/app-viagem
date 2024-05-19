
namespace Domain.UseCase.Trip
{
    public interface IGetTripAsync
    {
        public Task<Entities.Trip> GetTripAsync(long id);
    }

    public class GetAsync : IGetTripAsync
    {
        public Task<Entities.Trip> GetTripAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}
