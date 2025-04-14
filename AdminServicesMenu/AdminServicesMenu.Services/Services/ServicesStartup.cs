using AdminServicesMenu.Services.Services.PersonalSettings;
using AdminServicesMenu.Services.Services.Preset;
using AdminServicesMenu.Services.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AdminServicesMenu.Services.Services;

public static class ServicesStartup
{
    public static IServiceCollection AddServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IPersonalSettingsService, PersonalSettingsService>();
        serviceCollection.AddScoped<IPresetService, PresetService>();
        serviceCollection.AddScoped<IServiceService, ServiceService>();

        return serviceCollection;
    }
}