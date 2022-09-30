using System.Text.Json.Serialization;

namespace FortyTwoApi.Core.DataTransferObjects;

public class TheMovieDatabaseTvDto : TheMovieDatabaseBaseDto
{
    public string Name { get; init; }

    [JsonPropertyName("original_name")]
    public string OriginalName { get; init; }
    
    [JsonPropertyName("first_air_date")]
    public string FirstAirDate { get; init; }
}