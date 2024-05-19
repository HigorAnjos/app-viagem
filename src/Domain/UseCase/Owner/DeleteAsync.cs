using Domain.Repository;

namespace Domain.UseCase.Owner
{
    public interface IDeleteOwnerAsync
    {
        public Task<bool> DeleteOwnerAsync(long id);
    }

    public class DeleteAsync : IDeleteOwnerAsync
    {
        private readonly IService _service;

        public DeleteAsync(IService service)
        {
            _service = service;
        }

        public async Task<bool> DeleteOwnerAsync(long id)
        {
            return await _service.DeleteOwnerAsync(id);
        }
    }
}
