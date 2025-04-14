namespace AdminServicesMenu.Core.Domain;

public interface IServiceInfo
{
    public string Key { get; }
    public string Title { get; }
    public string Subtitle { get; }
    public string Link { get; }
    public string Icon { get; }
    public bool? NoReferrer { get; }
}

public record Service(string Id, string Key, string Title, string Subtitle, string Link, string Icon, bool? NoReferrer) 
    : Entity(Id), IServiceInfo
{
    public PromoPeriod? PromoPeriod { get; set; }
}

public record PromoPeriod(string Id) : Entity(Id)
{
    private readonly DateTime? _startDate;
    private readonly DateTime? _endDate;
    
    public DateTime? StartDate
    {
        get => _startDate;
        init => _startDate = value?.Date;
    }

    public DateTime? EndDate
    {
        get => _endDate;
        init => _endDate = value?.Date;
    }
}