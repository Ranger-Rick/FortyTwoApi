namespace FortyTwoApi.Core.Interfaces;

public interface IInstance
{
    MediaType MediaType { get; }

    string Title { get; init; }
    
    string Description { get; set; }
    
    DateTime ReleasedOn { get; init; }
    
    bool Explicit { get; init; }
}