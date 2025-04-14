using AdminServicesMenu.Services.Services.PersonalSettings;
using AdminServicesMenu.Services.Services.Preset;
using Microsoft.Extensions.DependencyInjection;

namespace AdminServicesMenu.Services.Services;

public static class ServicesStartup
{
    public static IServiceCollection AddServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IPersonalSettingsService, PersonalSettingsService>();
        serviceCollection.AddScoped<IPresetService, PresetService>();

        return serviceCollection;
    }
}