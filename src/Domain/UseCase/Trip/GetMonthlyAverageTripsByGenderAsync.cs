using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCase.Trip
{
    public class MonthlyAverageTripsByGenderDto
    {
        public DateTime Month { get; set; }
        public string PassengerGender { get; set; }
        public double MonthlyAverageTrips { get; set; }
    }

    public interface IGetMonthlyAverageTripsByGenderAsync
    {
        public Task<IEnumerable<MonthlyAverageTripsByGenderDto>> GetMonthlyAverageTrips();
    }

    public class GetMonthlyAverageTripsByGenderAsync : IGetMonthlyAverageTripsByGenderAsync
    {
        private readonly IService _service;

        public GetMonthlyAverageTripsByGenderAsync(IService service)
        {
            _service = service;
        }

        public async Task<IEnumerable<MonthlyAverageTripsByGenderDto>> GetMonthlyAverageTrips()
        {
            return await _service.GetMonthlyAverageTrips();
        }
    }
}
