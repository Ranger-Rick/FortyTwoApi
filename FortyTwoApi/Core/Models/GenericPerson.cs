using FortyTwoApi.Core.Interfaces;

namespace FortyTwoApi.Core.Models;

public class GenericPerson : IPerson
{
    public string FullName { get; set; } = "";
    public DateTime DateOfBirth { get; init; }
    public Gender Gender { get; set; }
}