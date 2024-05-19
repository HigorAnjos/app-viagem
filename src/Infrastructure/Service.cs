using Domain.Entities;
using Domain.Repository;

namespace Infrastructure
{
    public class Service : IService
    {
        public Task<bool> DeleteDriverByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<Driver> GetDriverByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<Driver> SaveDriverAsync(Driver driver)
        {
            throw new NotImplementedException();
        }
    }
}
