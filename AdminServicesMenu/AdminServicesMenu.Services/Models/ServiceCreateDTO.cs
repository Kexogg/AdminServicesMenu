namespace AdminServicesMenu.Services.Models;

public record ServiceCreateDTO(string Key, string Title, string Subtitle, string Link, string Icon, bool? NoReferrer);