namespace FortyTwoApi.Core.DataTransferObjects;

public class TheMovieDatabaseMovieCreditsDto
{
    public List<TheMovieDatabaseCastDto> Cast { get; init; }
    public List<TheMovieDatabaseCrewDto> Crew { get; init; }
    
}