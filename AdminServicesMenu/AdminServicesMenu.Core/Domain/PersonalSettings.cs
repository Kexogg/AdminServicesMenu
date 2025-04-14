namespace AdminServicesMenu.Core.Domain;

public record PersonalSettings(string Id) : Entity(Id)
{
    public Favorite[] Favorites { get; set; } = Array.Empty<Favorite>();
    public DateTime ModifiedAt { get; set; }
}