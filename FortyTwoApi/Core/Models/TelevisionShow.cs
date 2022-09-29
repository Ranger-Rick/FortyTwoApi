using FortyTwoApi.Core.Interfaces;

namespace FortyTwoApi.Core.Models;

public class TelevisionShow : IVideoInstance, ICanBeSpoiled
{
    public MediaType MediaType => MediaType.TvShow;
    public string Title { get; init; } = "";
    public string Description { get; set; } = "";
    public DateTime ReleasedOn { get; init; }
    public bool Explicit { get; init; }
    public List<IPerson> Directors { get; init; } = new();
    public List<IPerson> Writers { get; init; } = new();
    public List<IPerson> Actors { get; init; } = new();
    public string Studio { get; init; } = "";
    public bool InstanceContainsSpoilers { get; set; }
    
    public int Season { get; init; }
    public int Episode { get; init; }
}