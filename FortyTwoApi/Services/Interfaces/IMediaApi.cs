using FortyTwoApi.Core;
using FortyTwoApi.Core.Interfaces;

namespace FortyTwoApi.Services.Interfaces;

public interface IMediaApi
{
    MediaType Type { get; }

    Task<List<IOption>> GetOptions(string search);

    Task<IInstance> GetMediaDetailsForInstance(string optionId);
}