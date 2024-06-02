using Domain.Entities;
using Domain.UseCase.Driver;
using Domain.UseCase.Owner;
using Domain.UseCase.Passenger;
using Domain.UseCase.Trip;
using Domain.UseCase.Vehicles;

namespace Domain.Repository
{
    public interface IService :
        IDeleteDriverByIdAsync,IGetDriverByIdAsync, ISaveDriverAsync,
        IDeleteOwnerAsync, IGetOwnerAsync, ISaveOwnerAsync,
        IDeletePassengerAsync, IGetPassengerAsync, ISavePassengerAsync,
        IDeleteTripAsync, IGetTripAsync, ISaveTripAsync,
        IDeleteVehiclesAsync, IGetVehiclesAsync, ISaveVehiclesAsync, IJourneyReportAsync, IGetTop20RevenuesAsync, IGetMonthlyAverageTripsByGenderAsync
    { }

}
