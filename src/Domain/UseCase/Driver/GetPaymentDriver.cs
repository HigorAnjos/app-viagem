namespace Domain.UseCase.Driver
{
    public interface IGetPaymentDriverAsync
    {
        public Task<long> GetPaymentDriverAsync(long driverId, DateTime paymentDay, IEnumerable<Entities.Trip> trips);

    }

    public class GetPaymentDriver : IGetPaymentDriverAsync
    {
        public async Task<long> GetPaymentDriverAsync(long driverId, DateTime paymentDay, IEnumerable<Entities.Trip> trips)
        {
            var totalPrice = trips.Where(x => x.CanceledByPassenger != false || x.CanceledByDriver != false)
                                .Where(x => x.TripDate == paymentDay)
                                .Sum(x => x.Price);

            return (long)totalPrice;
        }
    }
}
