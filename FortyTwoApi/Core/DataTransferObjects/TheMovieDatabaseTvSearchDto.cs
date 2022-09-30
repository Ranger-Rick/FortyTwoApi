namespace FortyTwoApi.Core.DataTransferObjects;

public class TheMovieDatabaseTvSearchDto
{
    public int Page { get; init; }
    public List<TheMovieDatabaseTvDto> Results { get; init; }
}