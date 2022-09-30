using System.Text.Json.Serialization;

namespace FortyTwoApi.Core.DataTransferObjects;

public class TheMovieDatabaseTvDetailsDto : TheMovieDatabaseTvDto
{
    [JsonPropertyName("created_by")]
    public List<TheMovieDatabasePersonDto> CreatedBy { get; init; }
    
    [JsonPropertyName("number_of_episodes")]
    public int NumberOfEpisodes { get; init; }
    
    [JsonPropertyName("number_of_seasons")]
    public int NumberOfSeasons { get; init; }
    
    [JsonPropertyName("production_companies")]
    public List<TheMovieDatabaseProductionCompanyDto>? ProductionCompanies { get; init; }
    
    public List<TheMovieDatabaseSeasonDto> Seasons { get; init; }
}