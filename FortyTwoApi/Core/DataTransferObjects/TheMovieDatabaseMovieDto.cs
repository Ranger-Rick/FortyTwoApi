using System.Text.Json.Serialization;

namespace FortyTwoApi.Core.DataTransferObjects;

public class TheMovieDatabaseMovieDto : TheMovieDatabaseBaseDto
{
    public string Title { get; init; }
    
    [JsonPropertyName("original_title")]
    public string OriginalTitle { get; init; }
    
    [JsonPropertyName("release_date")]
    public string ReleaseDate { get; init; }
}