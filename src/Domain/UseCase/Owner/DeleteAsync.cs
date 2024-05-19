namespace Domain.UseCase.Owner
{
    public interface IDeleteOwnerAsync
    {
        public Task<bool> DeleteOwnerAsync(long id);
    }

    public class DeleteAsync : IDeleteOwnerAsync
    {
        public Task<bool> DeleteOwnerAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}
