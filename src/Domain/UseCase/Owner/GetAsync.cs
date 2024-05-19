using Domain.Repository;

namespace Domain.UseCase.Owner
{
    public interface IGetOwnerAsync
    {
        public Task<Entities.Owner> GetOwnerAsync(long id);
    }

    public class GetAsync : IGetOwnerAsync
    {
        private readonly IService _service;

        public GetAsync(IService service)
        {
            _service = service;
        }

        public async Task<Entities.Owner> GetOwnerAsync(long id)
        {
            return await _service.GetOwnerAsync(id);
        }
    }
}
