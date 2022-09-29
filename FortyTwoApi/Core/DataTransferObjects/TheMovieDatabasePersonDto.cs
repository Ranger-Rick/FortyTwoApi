using System.Text.Json.Serialization;

namespace FortyTwoApi.Core.DataTransferObjects;

public class TheMovieDatabasePersonDto
{
    public int Id { get; init; }
    public string Name { get; init; }
    [JsonPropertyName("original_name")]
    public string OriginalName { get; init; }
    [JsonPropertyName("profile_path")]
    public string ProfilePath { get; init; }
    
}