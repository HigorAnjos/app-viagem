
using Domain.Repository;

namespace Domain.UseCase.Trip
{
    public interface IDeleteTripAsync
    {
        public Task<bool> DeleteTripAsync(long id);
    }

    public class DeleteAsync : IDeleteTripAsync
    {
        private readonly IService _service;

        public DeleteAsync(IService service)
        {
            _service = service;
        }

        public async Task<bool> DeleteTripAsync(long id)
        {
            return await _service.DeleteTripAsync(id);
        }
    }
}
