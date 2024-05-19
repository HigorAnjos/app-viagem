
using Domain.Entities;

namespace Domain.UseCase.Owner
{
    public interface ISaveOwnerAsync
    {
        public Task<Entities.Owner> SaveOwnerAsync(Entities.Owner owner);
    }

    public class SaveAsync : ISaveOwnerAsync
    {
        public Task<Entities.Owner> SaveOwnerAsync(Entities.Owner owner)
        {
            throw new NotImplementedException();
        }
    }
}
