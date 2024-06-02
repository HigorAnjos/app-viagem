using Domain.Entities;
using Domain.Repository;

namespace Domain.UseCase.Trip
{
    public class JourneyReportDto
    {
        public string Brand { get; set; }
        public string Plate { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string DriverName { get; set; }
        public string PassengerName { get; set; }
    }

    public interface IJourneyReportAsync
    {
        public Task<IEnumerable<JourneyReportDto>> GetJourneyReportAsync(string brand, DateTime initDate, DateTime endDate);
    }

    public class JourneyReportAsync : IJourneyReportAsync
    {
        private readonly IService _service;

        public JourneyReportAsync(IService service)
        {
            _service = service;
        }

        public async Task<IEnumerable<JourneyReportDto>> GetJourneyReportAsync(string brand, DateTime initDate, DateTime endDate)
        {
            return await _service.GetJourneyReportAsync(brand, initDate, endDate);
        }
    }
}
