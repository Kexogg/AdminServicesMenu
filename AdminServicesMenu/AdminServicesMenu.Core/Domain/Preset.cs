namespace AdminServicesMenu.Core.Domain;

public record Preset(string Id) : Entity(Id)
{
    public required Favorite[] Favorites { get; set; } = Array.Empty<Favorite>();
}