using System.Text.Json.Serialization;

namespace FortyTwoApi.Core.DataTransferObjects;

public class TheMovieDatabaseProductionCompanyDto
{
    public int Id { get; init; }
    
    [JsonPropertyName("logo_path")]
    public string? Logo { get; init; }
    
    public string Name { get; init; }
    
    [JsonPropertyName("origin_country")]
    public string OriginCountry { get; init; }
}