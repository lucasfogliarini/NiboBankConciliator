using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NiboBankConciliator.Core.Services;

namespace NiboBankConciliator.Core
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add all type of services: logical services, repository services, DbContext, ...
        /// </summary>
        /// <param name="serviceCollection"></param>
        public static IServiceCollection AddAllServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddLogicalServices();
            serviceCollection.AddRepositories();
            return serviceCollection;
        }

        /// <summary>
        /// Add logical services.
        /// </summary>
        /// <param name="serviceCollection"></param>
        public static void AddLogicalServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IBankReconciliationService, BankReconciliationService>();
        }

        /// <summary>
        /// Add repository services.
        /// </summary>
        /// <param name="serviceCollection"></param>
        public static void AddRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddBankConciliatorRepository();
        }

        /// <summary>
        /// Add BankConciliatorRepository and BankConciliatorDbContext
        /// </summary>
        /// <param name="serviceCollection"></param>
        public static void AddBankConciliatorRepository(this IServiceCollection serviceCollection)
        {
            var connectionString = @"Server=(localdb)\mssqllocaldb;Database=BankConciliatorDb; Trusted_Connection=True;";
            serviceCollection.AddDbContext<BankConciliatorDbContext>(options => options.UseSqlServer(connectionString));
            serviceCollection.AddScoped<IBankConciliatorRepository, BankConciliatorRepository>();
        }
    }
}
