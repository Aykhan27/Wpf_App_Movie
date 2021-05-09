using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using WpfAppFilm.Models;
using WpfAppFilm.Services;
using WpfAppFilm.Views;

namespace WpfAppFilm.ViewModels
{
    class HomeViewModel : ViewModelBase
    {
        private readonly IMovieApiClient _movieApiClient;
        public HomeViewModel(IMovieApiClient movieApiClient)
        {
            _movieApiClient = movieApiClient;
            Movies = new ObservableCollection<Search>();
        }

        private ObservableCollection<Search> _movies;
        public ObservableCollection<Search> Movies
        {
            get => _movies;
            set => Set(ref _movies, value);
        }

        private string _imageSource;
        public string imageSource
        {
            get => _imageSource;
            set => Set(ref _imageSource, value);
        }
        
        private string _title;
        public string Title
        {
            get => _title;
            set
            {
                Set(ref _title, value);
                SearchCommand.RaiseCanExecuteChanged();
            }
        }

        private Search _search;
        public Search SearchMovie
        {
            get => _search;
            set
            {
                Set(ref _search, value);
                SearchCommand.RaiseCanExecuteChanged();
            }
        }

        private RelayCommand _searchCommand;
        public RelayCommand SearchCommand => _searchCommand ??= new RelayCommand(
            () =>
            {
                Movies.Clear();
                if (_movieApiClient.IsExecuteMovie(Title))
                {
                    var movie = _movieApiClient.GetMovieByMovieName(Title);     
                    ObservableCollection<Search> search = new ObservableCollection<Search>();
                    foreach (var item in movie.Search)
                        search.Add(item);
                    Movies = search;
                }
            }
        );

        private RelayCommand<Search> _viewCommand;
        public RelayCommand<Search> ViewCommand => _viewCommand ??= new RelayCommand<Search>(
            param =>
            {
                imageSource = param.Poster;
                SearchMovie = param;
            }
        );
    }
}
