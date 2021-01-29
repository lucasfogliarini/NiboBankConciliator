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
    }
}
