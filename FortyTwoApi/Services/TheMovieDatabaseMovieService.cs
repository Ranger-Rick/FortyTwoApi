using FortyTwoApi.Core;
using FortyTwoApi.Core.DataTransferObjects;
using FortyTwoApi.Core.Interfaces;
using FortyTwoApi.Core.Models;
using FortyTwoApi.Services.Interfaces;
using Refit;

namespace FortyTwoApi.Services;

public class TheMovieDatabaseMovieService : TheMovieDatabaseBaseService, IMediaApi
{
    public MediaType Type => MediaType.Movie;
    
    public TheMovieDatabaseMovieService(IConfiguration configuration) : base(configuration)
    {
    }
    
    public async Task<List<IOption>> GetOptions(string search)
    {
        try
        {
            var response = await TheMovieDatabaseApi.SearchMovies(TheMovieDatabaseAuthentication, search);

            var output = new List<IOption>();

            foreach (var option in response.Results)
            {
                var releasedOnSuccess = DateTime.TryParse(option.ReleaseDate, out var releasedOn);
                var newOption = new GenericOption
                {
                    Identifier = option.Id,
                    PrimaryName = option.Title,
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
        
        var movieDetails = await TheMovieDatabaseApi.GetMovieDetails(TheMovieDatabaseAuthentication, id);

        var movieCredits = await TheMovieDatabaseApi.GetMovieCredits(TheMovieDatabaseAuthentication, id);
        
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