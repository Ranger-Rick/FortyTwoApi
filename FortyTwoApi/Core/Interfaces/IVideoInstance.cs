namespace FortyTwoApi.Core.Interfaces;

public interface IVideoInstance : IInstance
{
    List<IPerson> Directors { get; init; }
    List<IPerson> Writers { get; init; }
    List<IPerson> Actors { get; init; }
    
    string Studio { get; init; }
}