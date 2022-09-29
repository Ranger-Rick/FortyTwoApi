namespace FortyTwoApi.Core.Interfaces;

public interface IOption
{
    dynamic Identifier { get; init; }
    string PrimaryName { get; init; }
    string Description { get; init; }
    DateTime ReleasedOn { get; init; }
}