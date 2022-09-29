using FortyTwoApi.Core.Interfaces;

namespace FortyTwoApi.Core.Models;

public class Movie : IVideoInstance, ICanBeSpoiled
{
    public MediaType MediaType => MediaType.Movie; 
    public string Title { get; init; } = "";
    public string Description { get; set; } = "";
    public DateTime ReleasedOn { get; init; }
    public bool Explicit { get; init; }
    public List<IPerson> Directors { get; init; } = new();
    public List<IPerson> Writers { get; init; } = new();
    public List<IPerson> Actors { get; init; } = new();
    public string Studio { get; init; } = "";
    public bool InstanceContainsSpoilers { get; set; }
}