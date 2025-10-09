using CivicAlerts.Data.Models;

namespace CivicAlerts.Data.Repositories
{
    public interface IIncidentRepository
    {
        Task<IEnumerable<Incident>> GetAllAsync();
        Task<Incident?> GetByIdAsync(string id);
        Task AddAsync(Incident incident);
    }
}
