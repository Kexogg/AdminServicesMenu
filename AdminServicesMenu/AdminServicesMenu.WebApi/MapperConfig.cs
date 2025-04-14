using AdminServicesMenu.Core.Domain;
using AdminServicesMenu.Services.Models;
using AutoMapper;

namespace AdminServicesMenu.WebApi;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<PresetCreateDTO, Preset>();
        CreateMap<PresetUpdateDTO, Preset>();
        CreateMap<PresetResponseDTO, Preset>();
        CreateMap<PersonalSettingsCreateDTO, PersonalSettings>();
        CreateMap<PersonalSettingsUpdateDTO, PersonalSettings>();
        CreateMap<PersonalSettingsResponseDTO, PersonalSettings>();
        CreateMap<ServiceCreateDTO, Service>();
        CreateMap<ServiceUpdateDTO, Service>();
        CreateMap<ServiceResponseDTO, Service>();
    }
}