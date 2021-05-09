using WpfAppFilm.Models;

namespace WpfAppFilm.Services
{
    internal interface IMovieApiClient
    {
        Movie GetMovieByMovieName(string movieName);
        bool IsExecuteMovie(string movieName);
    }
}