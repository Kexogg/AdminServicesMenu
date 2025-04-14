using AdminServicesMenu.Core.Domain;

namespace AdminServicesMenu.Services.Models;

public record PersonalSettingsCreateDTO(Favorite[] Favorites, DateTime ModifiedAt);