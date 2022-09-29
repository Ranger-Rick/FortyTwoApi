using FortyTwoApi.Core;
using FortyTwoApi.Core.Interfaces;
using FortyTwoApi.Core.Models;
using FortyTwoApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FortyTwoApi.Controllers;

[ApiController]
[Route("[controller]")]
public class SearchMediaController
{
    private readonly List<IMediaApi> _mediaApis;

    public SearchMediaController
    (
        IEnumerable<IMediaApi> mediaApis
    )
    {
        _mediaApis = mediaApis.ToList();
    }

    [HttpGet]
    [Route("/GetOptions")]
    public async Task<IApiResponse<List<IOption>>> GetOptions(MediaType mediaType, string searchCriteria)
    {
        var mediaService = _mediaApis.FirstOrDefault(s => s.Type == mediaType);
        if (mediaService is null)
        {
            return new GenericApiResponse<List<IOption>>(false, "The Media Type you are searching for is currently unavailable");
        }

        var results = await mediaService.GetOptions(searchCriteria);

        if (results.Count == 0)
        {
            return new GenericApiResponse<List<IOption>>(false, "No Results found");
        }
        
        return new GenericApiResponse<List<IOption>>(results);
    }

    [HttpGet]
    [Route("/GetInstanceDetails")]
    public async Task<IApiResponse<IInstance>> GetInstanceDetails(MediaType mediaType, string id)
    {
        var mediaService = _mediaApis.FirstOrDefault(s => s.Type == mediaType);
        if (mediaService is null)
        {
            return new GenericApiResponse<IInstance>(false, "The Media Type you are searching for is currently unavailable");
        }

        var result = await mediaService.GetMediaDetailsForInstance(id);

        return new GenericApiResponse<IInstance>(result);
    }
}