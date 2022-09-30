using Refit;

namespace FortyTwoApi.Services;

public class TheMovieDatabaseBaseService
{
    protected string TheMovieDatabaseAuthentication => _configuration["Configuration:TheMovieDatabaseAuth"];
    private readonly IConfiguration _configuration;
    protected readonly ITheMovieDatabaseApi TheMovieDatabaseApi;

    public TheMovieDatabaseBaseService(IConfiguration configuration)
    {
        _configuration = configuration;
        TheMovieDatabaseApi = RestService.For<ITheMovieDatabaseApi>(_configuration["Urls:TheMovieDatabaseBaseUrl"]);
        
    }
}