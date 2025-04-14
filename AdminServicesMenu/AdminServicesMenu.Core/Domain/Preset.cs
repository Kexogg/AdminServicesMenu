namespace AdminServicesMenu.Core.Domain;

public record Preset(string Id) : Entity(Id)
{
    public Preset() : this(Guid.Empty.ToString())
    {
        
    }
    
    public required List<Favorite> Favorites { get; set; } = [];
}