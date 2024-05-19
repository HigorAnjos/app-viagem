namespace Domain.UseCase.Owner
{
    public interface IGetOwnerAsync
    {
        public Task<Entities.Owner> GetOwnerAsync(long id);
    }

    public class GetAsync : IGetOwnerAsync
    {
        public Task<Entities.Owner> GetOwnerAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}
