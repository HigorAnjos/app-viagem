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
            var query = await _scriptLoader.GetCachedScriptAsync(FolderPath, "Script_DeleteDriverById.sql");
            var command = new CommandDefinition(commandText: query, parameters: new { Id = id });
            var rowsAffected = await _connection.ExecuteAsync(command);
            return rowsAffected > 0;
        }

        public Task<bool> DeleteOwnerAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletePassengerAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteTripAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteVehiclesAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<Driver> GetDriverByIdAsync(long driverId)
        {
            var query = await _scriptLoader.GetCachedScriptAsync(FolderPath, "Script_GetDriver.sql");
            var command = new CommandDefinition(commandText: query, parameters: new { DriverId = driverId });
            return await _connection.QueryFirstOrDefaultAsync<Domain.Entities.Driver>(command);
        }

        public async Task<Driver> SaveDriverAsync(Driver driver)
        {
            string query;
            CommandDefinition command;

            if (driver?.Id == null || driver?.Id == 0)
            {
                // Carregar o script de inserção de novo motorista
                query = await _scriptLoader.GetCachedScriptAsync(FolderPath, "Script_NewDriver.sql");


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
                query = await _scriptLoader.GetCachedScriptAsync(FolderPath, "Script_UpdateDriver.sql");
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
                await _connection.ExecuteAsync(command); // Executa a atualização
            }

            return driver;
        }

        public Task<Owner> GetOwnerAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<Passenger> GetPassengerAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<Trip> GetTripAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<Vehicle> GetVehiclesAsync(long id)
        {
            throw new NotImplementedException();
        }



        public Task<Owner> SaveOwnerAsync(Owner owner)
        {
            throw new NotImplementedException();
        }

        public Task<Passenger> SavePassengerAsync(Passenger passenger)
        {
            throw new NotImplementedException();
        }

        public Task<Trip> SaveTripAsync(Trip trip)
        {
            throw new NotImplementedException();
        }

        public async Task<Vehicle> SaveVehiclesAsync(Vehicle vehicles)
        {
            throw new NotImplementedException();

        }
    }
}
