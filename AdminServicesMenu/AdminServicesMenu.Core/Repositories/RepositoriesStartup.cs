using AdminServicesMenu.Core.Repositories.Presets;
using AdminServicesMenu.Core.Repositories.PromoPeriods;
using AdminServicesMenu.Core.Repositories.Services;
using AdminServicesMenu.Core.Repositories.SettingsRepository;
using Microsoft.Extensions.DependencyInjection;

namespace AdminServicesMenu.Core.Repositories;

public static class RepositoriesStartup
{
    public static IServiceCollection AddRepositories(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IPresetRepository, PresetRepository>();
        serviceCollection.AddScoped<IServicesRepository, ServicesRepository>();
        serviceCollection.AddScoped<IPromoPeriodRepository, PromoPeriodRepository>();
        serviceCollection.AddScoped<IPersonalSettingRepository, PersonalSettingsRepository>();

        return serviceCollection;
    }
}