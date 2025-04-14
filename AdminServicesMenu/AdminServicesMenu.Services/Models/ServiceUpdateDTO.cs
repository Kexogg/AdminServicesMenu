namespace AdminServicesMenu.Services.Models;

public record ServiceUpdateDTO(string Key, string Title, string Subtitle, string Link, string Icon, bool? NoReferrer);