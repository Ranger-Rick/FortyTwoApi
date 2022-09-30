using System.Text.Json.Serialization;

namespace FortyTwoApi.Core.DataTransferObjects;

public class TheMovieDatabaseBaseDto
{
    [JsonPropertyName("id")]
    public int Id { get; init; }
    
    [JsonPropertyName("backdrop_path")]
    public string? BackdropPath { get; init; }
    
    public string Overview { get; init; }
    
    [JsonPropertyName("poster_path")]
    public string? Poster { get; init; }
}