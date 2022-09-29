using FortyTwoApi.Core.Interfaces;

namespace FortyTwoApi.Core.Models;

public class GenericApiResponse<T> : IApiResponse<T>
{
    public bool Success { get; set; } = true;
    public string? ErrorMessage { get; set; }
    public T? Result { get; set; }
    
    public GenericApiResponse(T result)
    {
        Result = result;
    }

    public GenericApiResponse(bool success, string? errorMessage = null)
    {
        Success = success;
        ErrorMessage = errorMessage;
    }
}