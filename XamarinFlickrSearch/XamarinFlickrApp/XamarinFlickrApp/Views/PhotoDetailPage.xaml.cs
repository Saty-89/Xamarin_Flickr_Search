using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFlickr.Models;
using XamarinFlickr.ViewModels;

namespace XamarinFlickr.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PhotoDetailPage : ContentPage
    {
        public PhotoDetailPage(FlickrPhotoModel photoModel)
        {
            InitializeComponent();

            BindingContext = new PhotoDetailViewModel() { PhotoModel = photoModel };
        }
    }
}