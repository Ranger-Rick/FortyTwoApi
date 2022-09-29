using FortyTwoApi.Core.DataTransferObjects;
using Refit;

namespace FortyTwoApi.Services;

public interface IRefitApi
{
}

public interface ITheMovieDatabaseApi : IRefitApi
{
    [Get("/3/search/movie")]
    Task<TheMovieDatabaseMovieSearchDto> SearchMovies([Header("Authorization")] string authorization, string query);

    [Get("/3/movie/{id}")]
    Task<TheMovieDatabaseMovieDetailsDto> GetMovieDetails([Header("Authorization")] string authorization, int id);

    [Get("/3/movie/{id}/credits")]
    Task<TheMovieDatabaseMovieCreditsDto> GetMovieCredits([Header("Authorization")] string authorization, int id);
}