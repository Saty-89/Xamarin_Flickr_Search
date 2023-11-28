using XamarinFlickr.Models;

namespace XamarinFlickr.ViewModels
{
    public class PhotoDetailViewModel : BaseViewModel
    {
        private FlickrPhotoModel _photoModel;

        public FlickrPhotoModel PhotoModel
        {
            get => _photoModel;
            set
            {
                _photoModel = value;
                NotifyPropertyChanged(nameof(PhotoModel));
            }
        }
    }
}
