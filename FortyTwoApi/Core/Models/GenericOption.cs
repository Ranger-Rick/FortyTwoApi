using FortyTwoApi.Core.Interfaces;

namespace FortyTwoApi.Core.Models;

public class GenericOption : IOption
{
    public dynamic Identifier { get; init; } = "";
    public string PrimaryName { get; init; } = "";
    public string Description { get; init; } = "";
    public DateTime ReleasedOn { get; init; }
}