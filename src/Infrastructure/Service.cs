using Dapper;
using Domain.Abstractions;
using Domain.Entities;
using Domain.Repository;
using Infrastructure.Options;
using Microsoft.Extensions.Options;
using Npgsql;
using System.Data;


namespace Infrastructure
{
    public class Service : RepositoryBase, IService
    {
        private readonly IOptionsSnapshot<ConnectionStrings> _options;
        private readonly IDbConnection _connection;
        private readonly IScriptLoader _scriptLoader;

        public Service(IOptionsSnapshot<ConnectionStrings> options, IScriptLoader scriptLoader)
        {
            _options = options;
            //_connection = new System.Data.SqlClient.SqlConnection(options.Value.PostgresConnectionString);
            _connection = new NpgsqlConnection(options.Value.PostgresConnectionString); // var connectionString = "Server=127.0.0.1;Port=5432;Database=DapperDB;User Id=postgres;Password=z;";
            _scriptLoader = scriptLoader;
        }

        protected override string FolderPath => "Infrastructure";

        public async Task<bool> DeleteDriverByIdAsync(long id)
        {
            var query = await _scriptLoader.GetCachedScriptAsync(FolderPath, "Driver.Script_DeleteDriverById.sql");
            var command = new CommandDefinition(commandText: query, parameters: new { Id = id });
            var rowsAffected = await _connection.ExecuteAsync(command);
            return rowsAffected > 0;
        }

        public async Task<Driver> GetDriverByIdAsync(long driverId)
        {
            var query = await _scriptLoader.GetCachedScriptAsync(FolderPath, "Driver.Script_GetDriver.sql");
            var command = new CommandDefinition(commandText: query, parameters: new { DriverId = driverId });
            return await _connection.QueryFirstOrDefaultAsync<Domain.Entities.Driver>(command);
        }

        public async Task<Driver> SaveDriverAsync(Driver driver)
        {
            try
            {
                string query;
                CommandDefinition command;

                if (driver?.Id == null || driver?.Id == 0)
                {
                    // Carregar o script de inserção de novo motorista
                    query = await _scriptLoader.GetCachedScriptAsync(FolderPath, "Driver.Script_NewDriver.sql");


                    var parameters = new
                    {
                        Name = driver.Name,
                        CPF = driver.CPF,
                        Address = driver.Address,
                        Phone = driver.Phone,
                        CNH = driver.CNH,
                        Bank = driver.Bank,
                        Agency = driver.Agency,
                        Account = driver.Account
                    };
                    command = new CommandDefinition(commandText: query, parameters: parameters);
                    driver.Id = await _connection.ExecuteScalarAsync<int>(command); // Retorna o ID gerado
                }
                else
                {
                    // Carregar o script de atualização do motorista
                    query = await _scriptLoader.GetCachedScriptAsync(FolderPath, "Driver.Script_UpdateDriver.sql");
                    var parameters = new
                    {
                        Id = driver.Id,
                        Name = driver.Name,
                        CPF = driver.CPF,
                        Address = driver.Address,
                        Phone = driver.Phone,
                        CNH = driver.CNH,
                        Bank = driver.Bank,
                        Agency = driver.Agency,
                        Account = driver.Account
                    };
                    command = new CommandDefinition(commandText: query, parameters: parameters);
                    await _connection.ExecuteAsync(command);
                }

                return driver;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while saving the driver.", ex);
            }
        }

        public async Task<bool> DeleteOwnerAsync(long id)
        {
            var query = await _scriptLoader.GetCachedScriptAsync(FolderPath, "Owner.Script_DeleteOwnerById.sql");
            var command = new CommandDefinition(commandText: query, parameters: new { Id = id });
            var rowsAffected = await _connection.ExecuteAsync(command);
            return rowsAffected > 0;
        }

        public async Task<Owner> GetOwnerAsync(long id)
        {
            var query = await _scriptLoader.GetCachedScriptAsync(FolderPath, "Owner.Script_GetOwner.sql");
            var command = new CommandDefinition(commandText: query, parameters: new { OwnerId = id });
            return await _connection.QueryFirstOrDefaultAsync<Owner>(command);
        }

        public async Task<Owner> SaveOwnerAsync(Owner owner)
        {
            try
            {
                string query;
                CommandDefinition command;

                if (owner?.Id == null || owner?.Id == 0)
                {
                    query = await _scriptLoader.GetCachedScriptAsync(FolderPath, "Owner.Script_NewOwner.sql");
                    var parameters = new
                    {
                        Name = owner.Name,
                        CPF = owner.CPF,
                        Address = owner.Address,
                        Phone = owner.Phone,
                        CNH = owner.CNH,
                        Bank = owner.Bank,
                        Agency = owner.Agency,
                        Account = owner.Account
                    };
                    command = new CommandDefinition(commandText: query, parameters: parameters);
                    owner.Id = await _connection.ExecuteScalarAsync<int>(command);
                }
                else
                {
                    query = await _scriptLoader.GetCachedScriptAsync(FolderPath, "Owner.Script_UpdateOwner.sql");
                    var parameters = new
                    {
                        Id = owner.Id,
                        Name = owner.Name,
                        CPF = owner.CPF,
                        Address = owner.Address,
                        Phone = owner.Phone,
                        CNH = owner.CNH,
                        Bank = owner.Bank,
                        Agency = owner.Agency,
                        Account = owner.Account
                    };
                    command = new CommandDefinition(commandText: query, parameters: parameters);
                    await _connection.ExecuteAsync(command);
                }

                return owner;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while saving the Owner.", ex);
            }


        }

        public async Task<bool> DeletePassengerAsync(long id)
        {
            var query = await _scriptLoader.GetCachedScriptAsync(FolderPath, "Passenger.Script_DeletePassengerById.sql");
            var command = new CommandDefinition(commandText: query, parameters: new { Id = id });
            var rowsAffected = await _connection.ExecuteAsync(command);
            return rowsAffected > 0;
        }

        public async Task<Passenger> GetPassengerAsync(long id)
        {
            var query = await _scriptLoader.GetCachedScriptAsync(FolderPath, "Passenger.Script_GetPassenger.sql");
            var command = new CommandDefinition(commandText: query, parameters: new { PassengerId = id });
            return await _connection.QueryFirstOrDefaultAsync<Passenger>(command);
        }

        public async Task<Passenger> SavePassengerAsync(Passenger passenger)
        {
            try
            {
                string query;
                CommandDefinition command;

                if (passenger?.Id == null || passenger?.Id == 0)
                {
                    query = await _scriptLoader.GetCachedScriptAsync(FolderPath, "Passenger.Script_NewPassenger.sql");
                    var parameters = new
                    {
                        Name = passenger.Name,
                        Address = passenger.Address,
                        Phone = passenger.Phone,
                        CreditCard = passenger.CreditCard,
                        Gender = passenger.Gender,
                        CityOfOrigin = passenger.CityOfOrigin,
                        Email = passenger.Email,
                    };
                    command = new CommandDefinition(commandText: query, parameters: parameters);
                    passenger.Id = await _connection.ExecuteScalarAsync<int>(command);
                }
                else
                {
                    query = await _scriptLoader.GetCachedScriptAsync(FolderPath, "Passenger.Script_UpdatePassenger.sql");
                    var parameters = new
                    {
                        Id = passenger.Id,
                        Name = passenger.Name,
                        Address = passenger.Address,
                        Phone = passenger.Phone,
                        CreditCard = passenger.CreditCard,
                        Gender = passenger.Gender,
                        CityOfOrigin = passenger.CityOfOrigin,
                        Email = passenger.Email,
                    };
                    command = new CommandDefinition(commandText: query, parameters: parameters);
                    await _connection.ExecuteAsync(command);
                }

                return passenger;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while saving the Passenger.", ex);
            }
        }


        public async Task<bool> DeleteTripAsync(long id)
        {
            var query = await _scriptLoader.GetCachedScriptAsync(FolderPath, "Trip.Script_DeleteTripById.sql");
            var command = new CommandDefinition(commandText: query, parameters: new { Id = id });
            var rowsAffected = await _connection.ExecuteAsync(command);
            return rowsAffected > 0;
        }


        public async Task<Trip> GetTripAsync(long id)
        {
            var query = await _scriptLoader.GetCachedScriptAsync(FolderPath, "Trip.Script_GetTrip.sql");
            var command = new CommandDefinition(commandText: query, parameters: new { TripId = id });
            return await _connection.QueryFirstOrDefaultAsync<Trip>(command);
        }

        public async Task<Trip> SaveTripAsync(Trip trip)
        {
            try
            {

                string query;
                CommandDefinition command;

                if (trip?.Id == null || trip?.Id == 0)
                {
                    query = await _scriptLoader.GetCachedScriptAsync(FolderPath, "Trip.Script_NewTrip.sql");
                    var parameters = new
                    {
                        DriverVehicleId = trip.DriverVehicleId,
                        PassengerId = trip.PassengerId,
                        PaymentTypeId = trip.PaymentTypeId,
                        AuthorizedManagerCode = trip.AuthorizedManagerCode,
                        CanceledByDriver = trip.CanceledByDriver,
                        CanceledByPassenger = trip.CanceledByPassenger,
                        Price = trip.Price,
                        TripDate = trip.TripDate
                    };
                    command = new CommandDefinition(commandText: query, parameters: parameters);
                    trip.Id = await _connection.ExecuteScalarAsync<int>(command);
                }
                else
                {
                    query = await _scriptLoader.GetCachedScriptAsync(FolderPath, "Trip.Script_UpdateTrip.sql");
                    var parameters = new
                    {
                        Id = trip.Id,
                        DriverVehicleId = trip.DriverVehicleId,
                        PassengerId = trip.PassengerId,
                        PaymentTypeId = trip.PaymentTypeId,
                        AuthorizedManagerCode = trip.AuthorizedManagerCode,
                        CanceledByDriver = trip.CanceledByDriver,
                        CanceledByPassenger = trip.CanceledByPassenger,
                        Price = trip.Price,
                        TripDate = trip.TripDate
                    };
                    command = new CommandDefinition(commandText: query, parameters: parameters);
                    await _connection.ExecuteAsync(command);
                }

                return trip;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while saving the Trip.", ex);
            }
        }

        public async Task<bool> DeleteVehiclesAsync(long id)
        {
            var query = await _scriptLoader.GetCachedScriptAsync(FolderPath, "Vehicle.Script_DeleteVehicleById.sql");
            var command = new CommandDefinition(commandText: query, parameters: new { Id = id });
            var rowsAffected = await _connection.ExecuteAsync(command);
            return rowsAffected > 0;
        }

        public async Task<Vehicle> GetVehiclesAsync(long id)
        {
            var query = await _scriptLoader.GetCachedScriptAsync(FolderPath, "Vehicle.Script_GetVehicle.sql");
            var command = new CommandDefinition(commandText: query, parameters: new { VehicleId = id });
            return await _connection.QueryFirstOrDefaultAsync<Vehicle>(command);
        }

        public async Task<Vehicle> SaveVehiclesAsync(Vehicle vehicle)
        {
            try
            {

                string query;
                CommandDefinition command;

                if (vehicle?.Id == null || vehicle?.Id == 0)
                {
                    query = await _scriptLoader.GetCachedScriptAsync(FolderPath, "Vehicle.Script_NewVehicle.sql");
                    var parameters = new
                    {
                        OwnerId = vehicle.OwnerId,
                        LicensePlate = vehicle.LicensePlate,
                        Brand = vehicle.Brand,
                        Model = vehicle.Model,
                        ManufactureYear = vehicle.ManufactureYear,
                        Capacity = vehicle.Capacity,
                        Color = vehicle.Color,
                        FuelType = vehicle.FuelType,
                        EnginePower = vehicle.EnginePower
                    };
                    command = new CommandDefinition(commandText: query, parameters: parameters);
                    vehicle.Id = await _connection.ExecuteScalarAsync<int>(command);
                }
                else
                {
                    query = await _scriptLoader.GetCachedScriptAsync(FolderPath, "Vehicle.Script_UpdateVehicle.sql");
                    var parameters = new
                    {
                        Id = vehicle.Id,
                        OwnerId = vehicle.OwnerId,
                        LicensePlate = vehicle.LicensePlate,
                        Brand = vehicle.Brand,
                        Model = vehicle.Model,
                        ManufactureYear = vehicle.ManufactureYear,
                        Capacity = vehicle.Capacity,
                        Color = vehicle.Color,
                        FuelType = vehicle.FuelType,
                        EnginePower = vehicle.EnginePower
                    };
                    command = new CommandDefinition(commandText: query, parameters: parameters);
                    await _connection.ExecuteAsync(command);
                }

                return vehicle;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while saving the Passenger.", ex);
            }
        }
    }
}
