using Domain.Repository;

namespace Domain.UseCase.Driver
{
    public interface IGetDriverByIdAsync
    {
        public Task<Entities.Driver> GetDriverByIdAsync(long id);

    }

    public class GetAsync : IGetDriverByIdAsync
    {
        private readonly IService _service;

        public GetAsync(IService service)
        {
            _service = service;
        }

        public async Task<Entities.Driver> GetDriverByIdAsync(long id)
        {
            return await _service.GetDriverByIdAsync(id);
        }
    }
}
