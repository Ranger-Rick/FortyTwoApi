using FortyTwoApi.Core.Interfaces;

namespace FortyTwoApi.Core.Models;

public class GenericInstance : IInstance
{
    public MediaType MediaType { get; set; } = MediaType.Other;
    public string Title { get; init; } = "";
    public string Description { get; set; } = "";
    public DateTime ReleasedOn { get; init; }
    public bool Explicit { get; init; }
}