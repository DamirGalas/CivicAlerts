using CivicAlerts.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CivicAlerts.Data
{
    public static class DataExtensions
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, string connectionString)
        {
            services.AddSingleton<IIncidentRepository>(sp => new IncidentRepository(connectionString));
            return services;
        }
    }
}
