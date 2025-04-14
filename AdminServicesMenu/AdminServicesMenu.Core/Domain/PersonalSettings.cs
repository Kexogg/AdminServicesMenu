namespace AdminServicesMenu.Core.Domain;

public record PersonalSettings(string Id) : Entity(Id)
{
    public List<Favorite> Favorites { get; set; } = [];
    public DateTime ModifiedAt { get; set; }
}