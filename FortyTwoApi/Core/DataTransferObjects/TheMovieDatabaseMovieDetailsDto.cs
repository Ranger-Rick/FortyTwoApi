using System.Text.Json.Serialization;

namespace FortyTwoApi.Core.DataTransferObjects;

public class TheMovieDatabaseMovieDetailsDto : TheMovieDatabaseMovieDto
{
    [JsonPropertyName("production_companies")]
    public List<ProductionCompany>? ProductionCompanies { get; init; }

    //TODO: Add genres once a universal genre object is created
}

public class ProductionCompany
{
    public int Id { get; init; }
    
    [JsonPropertyName("logo_path")]
    public string? Logo { get; init; }
    
    public string Name { get; init; }
    
    [JsonPropertyName("origin_country")]
    public string OriginCountry { get; init; }
}