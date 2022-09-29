namespace FortyTwoApi.Core.Interfaces;

public interface IApiResponse<T>
{
    bool Success { get; set; }
    string? ErrorMessage { get; set; }
    T? Result { get; set; }
}