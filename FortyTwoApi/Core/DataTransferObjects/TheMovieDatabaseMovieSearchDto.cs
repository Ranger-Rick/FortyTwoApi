using System.Text.Json.Serialization;

namespace FortyTwoApi.Core.DataTransferObjects;

public class TheMovieDatabaseMovieSearchDto
{
    public int Page { get; init; }
    public List<TheMovieDatabaseMovieDto> Results { get; init; }
}