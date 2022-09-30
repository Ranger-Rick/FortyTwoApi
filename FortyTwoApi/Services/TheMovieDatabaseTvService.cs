using FortyTwoApi.Core;
using FortyTwoApi.Core.Interfaces;
using FortyTwoApi.Core.Models;
using FortyTwoApi.Services.Interfaces;

namespace FortyTwoApi.Services;

public class TheMovieDatabaseTvService : TheMovieDatabaseBaseService, IMediaApi
{
    public MediaType Type => MediaType.TvShow;
    
    public TheMovieDatabaseTvService(IConfiguration configuration) : base(configuration)
    {
    }
    
    public async Task<List<IOption>> GetOptions(string search)
    {
        var response = await TheMovieDatabaseApi.SearchTelevision(TheMovieDatabaseAuthentication, search);
        var output = new List<IOption>();

        foreach (var show in response.Results)
        {
            var firstAirDateSuccess = DateTime.TryParse(show.FirstAirDate, out var firstAirDate);
            var newOption = new GenericOption
            {
                Identifier = show.Id,
                PrimaryName = show.Name,
                Description = show.Overview,
                ReleasedOn = firstAirDateSuccess ? firstAirDate : DateTime.Now
            };
            
            output.Add(newOption);
        }

        return output;
    }

    public async Task<IInstance> GetMediaDetailsForInstance(string optionId)
    {
        var idParseSuccess = int.TryParse(optionId, out var id);

        if (!idParseSuccess) return new TelevisionShow();

        var showDetails = await TheMovieDatabaseApi.GetTelevisionDetails(TheMovieDatabaseAuthentication, id);
        
        var firstAirDateSuccess = DateTime.TryParse(showDetails.FirstAirDate, out var firstAirDate);
        var output = new GenericInstance
        {
            MediaType = MediaType.TvShow,
            Title = showDetails.Name,
            Description = showDetails.Overview,
            ReleasedOn = firstAirDateSuccess ? firstAirDate : DateTime.Now
        };

        return output;
    }
}