
using Domain.Entities;
using Domain.Repository;

namespace Domain.UseCase.Owner
{
    public interface ISaveOwnerAsync
    {
        public Task<Entities.Owner> SaveOwnerAsync(Entities.Owner owner);
    }

    public class SaveAsync : ISaveOwnerAsync
    {
        private readonly IService _service;

        public SaveAsync(IService service)
        {
            _service = service;
        }

        public async Task<Entities.Owner> SaveOwnerAsync(Entities.Owner owner)
        {
            return await _service.SaveOwnerAsync(owner);
        }
    }
}
