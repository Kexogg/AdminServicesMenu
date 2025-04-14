using AdminServicesMenu.Core.Domain;

namespace AdminServicesMenu.Services.Models;

public record PersonalSettingsUpdateDTO(Favorite[] Favorites, DateTime ModifiedAt);