namespace FortyTwoApi.Core.Interfaces;

public interface IPerson
{
    string FullName { get; set; }
    DateTime DateOfBirth { get; init; }
    Gender Gender { get; set; }
}