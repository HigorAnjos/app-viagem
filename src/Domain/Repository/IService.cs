using Domain.Entities;
using Domain.UseCase.Driver;

namespace Domain.Repository
{
    public interface IService : IGetDriverByIdAsync, IDeleteDriverByIdAsync, ISaveDriverAsync
    {

    }
}
