using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFlickr.Services;
using XamarinFlickr.Views;

namespace XamarinFlickr
{
    public partial class App : Application
    {
        public static FlickrPhotosManager FlickrManager { get; private set; } //init;

        public App()
        {
            InitializeComponent();

            FlickrManager = new FlickrPhotosManager();
            MainPage = new NavigationPage(new HomePage());
        }

        protected override void OnStart()
        {
            Debug.WriteLine(nameof(OnStart));
        }

        protected override void OnSleep()
        {
            Debug.WriteLine(nameof(OnSleep));
        }

        protected override void OnResume()
        {
            Debug.WriteLine(nameof(OnResume));
        }
    }
}
