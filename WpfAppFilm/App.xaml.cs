using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using SimpleInjector;
using WpfAppFilm.Services;
using WpfAppFilm.ViewModels;

namespace WpfAppFilm
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Container Services { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            RegisterServices();
        }

        private void RegisterServices()
        {
            Services = new Container();

            Services.Register<HomeViewModel>();
            Services.Register<IMovieApiClient,MovieApiClient>();

            Services.Verify();
        }

    }
}
