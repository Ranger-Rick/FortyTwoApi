using FortyTwoApi.Core.Interfaces;

namespace FortyTwoApi.Core.Models;

public class Book : IInstance, ICanBeSpoiled
{
    public MediaType MediaType => MediaType.Book;
    public string Title { get; init; } = "";
    public string Description { get; set; } = "";
    public DateTime ReleasedOn { get; init; }
    public bool Explicit { get; init; }
    public bool InstanceContainsSpoilers { get; set; }
    
    public int? Chapter { get; init; }
    public List<IPerson> Authors { get; init; } = new();
}