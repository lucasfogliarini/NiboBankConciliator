using Microsoft.Extensions.DependencyInjection;
using NiboBankConciliator.Core.Services;

namespace NiboBankConciliator.Core
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IBankReconciliationService, BankReconciliationService>();
        }

        public static void AddRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddBankConciliatorRepository();
        }

        public static void AddBankConciliatorRepository(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<BankConciliatorDbContext>();
            serviceCollection.AddScoped<IBankConciliatorRepository, BankConciliatorRepository>();
        }
    }
}
