using AdminServicesMenu.Core.Domain;

namespace AdminServicesMenu.Services.Models;

public record PresetResponseDTO(string Id, List<Favorite> Favorites);