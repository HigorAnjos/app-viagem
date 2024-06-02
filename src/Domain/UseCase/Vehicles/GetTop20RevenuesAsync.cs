using Domain.Repository;

namespace Domain.UseCase.Vehicles
{
    public class RevenuesDto
    {
        public string Brand { get; set; }
        public string Plate { get; set; }
        public string DriverName { get; set; }
        public decimal TotalRevenue { get; set; }
    }

    public interface IGetTop20RevenuesAsync
    {
        public Task<IEnumerable<RevenuesDto>> GetTopRevenuesAsync(DateTime month);
    }

    public class GetTop20RevenuesAsync : IGetTop20RevenuesAsync
    {
        private readonly IService _service;

        public GetTop20RevenuesAsync(IService service)
        {
            _service = service;
        }

        public async Task<IEnumerable<RevenuesDto>> GetTopRevenuesAsync(DateTime month)
        {
            return await _service.GetTopRevenuesAsync(month);
        }
    }
}
