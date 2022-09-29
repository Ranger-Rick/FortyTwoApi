using FortyTwoApi.Core.Interfaces;

namespace FortyTwoApi.Core.Models;

public class MusicVideo : IInstance
{
    public MediaType MediaType => MediaType.MusicVideo;
    public string Title { get; init; } = "";
    public string Description { get; set; } = "";
    public DateTime ReleasedOn { get; init; }
    public bool Explicit { get; init; }

    public List<IPerson> Artists { get; init; } = new();
}