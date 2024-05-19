using Dapper;
using Domain.Abstractions;
using Domain.Entities;
using Domain.Repository;
using Infrastructure.Options;
using Microsoft.Extensions.Options;
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
            _connection = new System.Data.SqlClient.SqlConnection(options.Value.PostgresConnectionString);
            _scriptLoader = scriptLoader;
        }

        protected override string FolderPath => "Infrastructure";

        public Task<bool> DeleteDriverByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<Driver> GetDriverByIdAsync(long driverId)
        {
            var query = await _scriptLoader.GetCachedScriptAsync(FolderPath, "Script_GetDriver.sql");
            var command = new CommandDefinition(commandText: query, parameters: new { DriverId = driverId });
            return await _connection.QueryFirstOrDefaultAsync<Domain.Entities.Driver>(command);
        }

        public Task<Driver> SaveDriverAsync(Driver driver)
        {
            throw new NotImplementedException();
        }
    }
}
