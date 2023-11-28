using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinFlickr.Models;

namespace XamarinFlickr.ViewModels
{
    public class SearchPhotosViewModel : BaseViewModel
    {
        private bool isBusy = false;
        private List<FlickrPhotoModel> _searchResults = new List<FlickrPhotoModel>();

        public bool IsBusy
        {
            get => isBusy;
            set
            {
                isBusy = value;
                NotifyPropertyChanged(nameof(IsBusy));
            }
        }
        public List<FlickrPhotoModel> SearchResults
        {
            get => _searchResults;
            set
            {
                _searchResults = value;
                NotifyPropertyChanged(nameof(SearchResults));
            }
        }

        public ICommand SearchPhotos => new Command<string>(async (string queryString) =>
        {
            IsBusy = true;
            SearchResults = await App.FlickrManager.GetPhotoListByText(queryString);
            await Task.Delay(100);
            IsBusy = false;
        });
    }
}
