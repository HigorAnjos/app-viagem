using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCase.Passenger
{
    public interface IDeletePassengerAsync
    {
        public Task<bool> DeletePassengerAsync(long id);
    }

    public class DeleteAsync : IDeletePassengerAsync
    {
        private readonly IService _service;

        public DeleteAsync(IService service)
        {
            _service = service;
        }

        public async Task<bool> DeletePassengerAsync(long id)
        {
            return await _service.DeletePassengerAsync(id);
        }
    }
}
