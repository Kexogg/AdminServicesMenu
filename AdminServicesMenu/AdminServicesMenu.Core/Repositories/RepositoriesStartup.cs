using AdminServicesMenu.Core.Repositories.PromoPeriods;
using Microsoft.Extensions.DependencyInjection;

namespace AdminServicesMenu.Core.Repositories;

public static class RepositoriesStartup
{
    public static IServiceCollection AddRepositories(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IPresetRepository, PresetRepository>();
        serviceCollection.AddScoped<IPromoPeriodRepository, PromoPeriodRepository>();

        return serviceCollection;
    }
}