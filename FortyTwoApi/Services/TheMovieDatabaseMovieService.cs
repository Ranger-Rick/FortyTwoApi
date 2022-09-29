using FortyTwoApi.Core;
using FortyTwoApi.Core.DataTransferObjects;
using FortyTwoApi.Core.Interfaces;
using FortyTwoApi.Core.Models;
using FortyTwoApi.Services.Interfaces;
using Refit;

namespace FortyTwoApi.Services;

public class TheMovieDatabaseMovieService : IMediaApi
{
    public MediaType Type => MediaType.Movie;

    private readonly IConfiguration _configuration;
    private readonly ITheMovieDatabaseApi _theMovieDatabase;
    
    public TheMovieDatabaseMovieService(IConfiguration configuration)
    {
        _configuration = configuration;
        _theMovieDatabase = RestService.For<ITheMovieDatabaseApi>(_configuration["Urls:TheMovieDatabaseBaseUrl"]);
    }
    public async Task<List<IOption>> GetOptions(string search)
    {
        try
        {
            var response = await _theMovieDatabase.SearchMovies(_configuration["Configuration:TheMovieDatabaseAuth"], search);

            var output = new List<IOption>();

            foreach (var option in response.Results)
            {
                var releasedOnSuccess = DateTime.TryParse(option.ReleaseDate, out var releasedOn);
                var newOption = new GenericOption
                {
                    Identifier = option.Id,
                    PrimaryName = option.OriginalTitle,
                    Description = option.Overview,
                    ReleasedOn = releasedOnSuccess ? releasedOn : DateTime.Now
                };
            
                output.Add(newOption);
            }

            return output;
        }
        catch (Exception e)
        {
            return new List<IOption>();
        }
    }

    public async Task<IInstance> GetMediaDetailsForInstance(string optionId)
    {
        var idParseSuccess = int.TryParse(optionId, out var id);

        if (!idParseSuccess) return new Movie();
        
        var movieDetails = await _theMovieDatabase.GetMovieDetails(_configuration["Configuration:TheMovieDatabaseAuth"], id);

        var movieCredits = await _theMovieDatabase.GetMovieCredits(_configuration["Configuration:TheMovieDatabaseAuth"], id);
        
        var releasedOnSuccess = DateTime.TryParse(movieDetails.ReleaseDate, out var releasedOn);
        
        var directors = GetPersons(movieCredits.Crew, "Director");

        var writers = GetPersons(movieCredits.Crew, "Screenplay");

        var cast = GetPersons(movieCredits.Cast);

        var output = new Movie
        {
            Title = movieDetails.OriginalTitle,
            Description = movieDetails.Overview,
            ReleasedOn = releasedOnSuccess ? releasedOn : DateTime.Now,
            Directors = new List<IPerson>(directors),
            Writers = new List<IPerson>(writers),
            Actors = new List<IPerson>(cast),
            Studio = movieDetails.ProductionCompanies?.FirstOrDefault()?.Name ?? ""
        };

        return output;
    }

    private List<GenericPerson> GetPersons(List<TheMovieDatabaseCrewDto> persons, string jobType)
    {
        var output = new List<GenericPerson>();

        foreach (var person in persons.Where(c => c.Job == jobType))
        {
            var newPerson = new GenericPerson
            {
                FullName = person.Name,
                Gender = Gender.Unknown
            };
            output.Add(newPerson);
        }

        return output;
    }

    private List<GenericPerson> GetPersons(List<TheMovieDatabaseCastDto> persons)
    {
        var output = new List<GenericPerson>();

        foreach (var person in persons)
        {
            var newPerson = new GenericPerson
            {
                FullName = person.Name,
                Gender = Gender.Unknown
            };
            output.Add(newPerson);
        }

        return output;
    }
}