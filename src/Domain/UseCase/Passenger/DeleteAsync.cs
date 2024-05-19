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
        public Task<bool> DeletePassengerAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}
