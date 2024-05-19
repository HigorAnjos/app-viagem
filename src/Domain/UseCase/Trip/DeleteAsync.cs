
namespace Domain.UseCase.Trip
{
    public interface IDeleteTripAsync
    {
        public Task<bool> DeleteTripAsync(long id);
    }

    public class DeleteAsync : IDeleteTripAsync
    {
        public Task<bool> DeleteTripAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}
