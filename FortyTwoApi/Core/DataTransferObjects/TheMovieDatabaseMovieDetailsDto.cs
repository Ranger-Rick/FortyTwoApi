using System.Text.Json.Serialization;

namespace FortyTwoApi.Core.DataTransferObjects;

public class TheMovieDatabaseMovieDetailsDto : TheMovieDatabaseMovieDto
{
    [JsonPropertyName("production_companies")]
    public List<TheMovieDatabaseProductionCompanyDto>? ProductionCompanies { get; init; }

    //TODO: Add genres once a universal genre object is created
}

