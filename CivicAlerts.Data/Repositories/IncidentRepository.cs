using CivicAlerts.Data.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CivicAlerts.Data.Repositories
{
    public class IncidentRepository : IIncidentRepository
    {
        private readonly string _connectionString;

        public IncidentRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        private IDbConnection CreateConnection() => new SqlConnection(_connectionString);

        public async Task<IEnumerable<Incident>> GetAllAsync()
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<Incident>("SELECT * FROM Incidents");
        }

        public async Task<Incident?> GetByIdAsync(string id)
        {
            using var connection = CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<Incident>(
                "SELECT * FROM Incidents WHERE Id = @Id", new { Id = id });
        }

        public async Task AddAsync(Incident incident)
        {
            using var connection = CreateConnection();
            var sql = @"INSERT INTO Incidents (Id, Title, Description, CreatedAt)
                        VALUES (@Id, @Title, @Description, @CreatedAt)";
            await connection.ExecuteAsync(sql, incident);
        }
    }
}
