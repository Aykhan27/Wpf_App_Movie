using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Windows;
using WpfAppFilm.Models;

namespace WpfAppFilm.Services
{
    internal class MovieApiClient : IMovieApiClient
    {
        private readonly WebClient _webClient;

        private readonly string _appId = "86fe5eb4";
        private readonly string _apiUrl = "http://www.omdbapi.com";

        public MovieApiClient()
        {
            _webClient = new WebClient();
        }

        public Movie GetMovieByMovieName(string movieName)
        {
            var json = _webClient.DownloadString($"{_apiUrl}/?apikey={_appId}&s={movieName}");
            var movie = JsonSerializer.Deserialize<Movie>(json);
            return movie;
        }

        public bool IsExecuteMovie(string movieName)
        {
            var json = _webClient.DownloadString($"{_apiUrl}/?apikey={_appId}&s={movieName}");
            var movie = JsonSerializer.Deserialize<Movie>(json);
            return bool.Parse(movie.Response);
        }
    }
}
