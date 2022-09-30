using System.Text.Json.Serialization;

namespace FortyTwoApi.Core.DataTransferObjects;

public class TheMovieDatabaseSeasonDto : TheMovieDatabaseBaseDto
{
    [JsonPropertyName("air_date")]
    public string AirDate { get; init; }
    
    [JsonPropertyName("episode_count")]
    public int EpisodeCount { get; init; }
    
    [JsonPropertyName("season_number")]
    public int SeasonNumber { get; init; }
    
}