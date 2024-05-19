using Domain.Repository;

namespace Domain.UseCase.Driver
{
    public interface IDeleteDriverByIdAsync
    {
        public Task<bool> DeleteDriverByIdAsync(long id);
    }

    public class DeleteAsync : IDeleteDriverByIdAsync
    {
        private readonly IService _service;

        public DeleteAsync(IService service)
        {
            _service = service;
        }

        public async Task<bool> DeleteDriverByIdAsync(long id)
        {
            return await _service.DeleteDriverByIdAsync(id);
        }
    }
}
