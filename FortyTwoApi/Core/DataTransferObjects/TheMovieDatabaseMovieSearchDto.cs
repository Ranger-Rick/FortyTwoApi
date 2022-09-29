using System.Text.Json.Serialization;

namespace FortyTwoApi.Core.DataTransferObjects;

public class TheMovieDatabaseMovieSearchDto
{
    public int Page { get; init; }
    public List<TheMovieDatabaseMovieDto> Results { get; init; }
}

public class TheMovieDatabaseMovieDto
{
    [JsonPropertyName("id")]
    public int Id { get; init; }
    
    [JsonPropertyName("backdrop_path")]
    public string? BackdropPath { get; init; }
    
    [JsonPropertyName("original_title")]
    public string OriginalTitle { get; init; }
    
    public string Overview { get; init; }
    
    [JsonPropertyName("poster_path")]
    public string? Poster { get; init; }
    
    [JsonPropertyName("release_date")]
    public string ReleaseDate { get; init; }
}