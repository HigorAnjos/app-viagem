using Domain.Repository;

namespace Domain.UseCase.Driver
{
    public interface ISaveDriverAsync
    {
        public Task<Domain.Entities.Driver> SaveDriverAsync(Domain.Entities.Driver driver);
    }

    public class SaveAsync : ISaveDriverAsync
    {
        private readonly IService _service;

        public SaveAsync(IService service)
        {
            _service = service;
        }

        public async Task<Domain.Entities.Driver> SaveDriverAsync(Entities.Driver driver)
        {
            return await _service.SaveDriverAsync(driver);
        }
    }

}
