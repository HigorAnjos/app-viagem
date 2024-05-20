using Domain.UseCase.Driver;
using Domain.UseCase.Owner;
using Domain.UseCase.Passenger;
using Domain.UseCase.Trip;
using Domain.UseCase.Vehicles;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
            => services.AddUseCases();

        private static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            #region Driver

            services.AddScoped<IDeleteDriverByIdAsync, UseCase.Driver.DeleteAsync>();
            services.AddScoped<IGetDriverByIdAsync, UseCase.Driver.GetAsync>();
            services.AddScoped<ISaveDriverAsync, UseCase.Driver.SaveAsync>();
            services.AddScoped<IGetPaymentDriverAsync, UseCase.Driver.GetPaymentDriver>();

            #endregion

            #region Owner
            services.AddScoped<IDeleteOwnerAsync, UseCase.Owner.DeleteAsync>();
            services.AddScoped<IGetOwnerAsync, UseCase.Owner.GetAsync>();
            services.AddScoped<ISaveOwnerAsync, UseCase.Owner.SaveAsync>();
            #endregion

            #region Passenger
            services.AddScoped<IDeletePassengerAsync, UseCase.Passenger.DeleteAsync>();
            services.AddScoped<IGetPassengerAsync, UseCase.Passenger.GetAsync>();
            services.AddScoped<ISavePassengerAsync, UseCase.Passenger.SaveAsync>();
            #endregion

            #region Trip
            services.AddScoped<IDeleteTripAsync, UseCase.Trip.DeleteAsync>();
            services.AddScoped<IGetTripAsync, UseCase.Trip.GetAsync>();
            services.AddScoped<ISaveTripAsync, UseCase.Trip.SaveAsync>();
            #endregion

            #region Vehicles
            services.AddScoped<IDeleteVehiclesAsync, UseCase.Vehicles.DeleteAsync>();
            services.AddScoped<IGetVehiclesAsync, UseCase.Vehicles.GetAsync>();
            services.AddScoped<ISaveVehiclesAsync, UseCase.Vehicles.SaveAsync>();
            #endregion

            return services;
        }
    }
}
