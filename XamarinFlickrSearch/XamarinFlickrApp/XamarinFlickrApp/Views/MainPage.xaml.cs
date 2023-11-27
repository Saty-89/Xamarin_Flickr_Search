using System;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFlickr.Models;

namespace XamarinFlickr.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            View button = sender as View;
            if (button != null)
            {
                FlickrPhotoModel photoModel = button.BindingContext as FlickrPhotoModel;
                if (photoModel != null)
                {
                    Page page = (Page)Activator.CreateInstance(typeof(PhotoDetail), photoModel);
                    Application.Current.MainPage.Navigation.PushAsync(page);
                }
            }
        }
    }
}
