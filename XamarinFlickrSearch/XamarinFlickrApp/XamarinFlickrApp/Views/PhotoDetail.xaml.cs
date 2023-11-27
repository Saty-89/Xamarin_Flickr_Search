using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFlickr.Models;
using XamarinFlickr.ViewModels;

namespace XamarinFlickr.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PhotoDetail : ContentPage
    {
        public PhotoDetail(FlickrPhotoModel photoModel)
        {
            InitializeComponent();

            BindingContext = new PhotoDetailViewModel() { PhotoModel = photoModel };
        }
    }
}