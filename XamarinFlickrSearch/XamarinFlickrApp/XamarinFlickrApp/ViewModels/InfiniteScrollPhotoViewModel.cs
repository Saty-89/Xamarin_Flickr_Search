using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinFlickr.Models;

namespace XamarinFlickr.ViewModels
{
    class InfiniteScrollPhotoViewModel : BaseViewModel
    {
        private const int RESULTS_PER_PAGE = 75;

        private bool _isBusy = false;
        private ObservableCollection<FlickrPhotoModel> _searchResults = new ObservableCollection<FlickrPhotoModel>();
        private int _pageIndex = 1;
        private int _totalPages = 1;
        private int _totalResults = 0;

        #region Properties

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                NotifyPropertyChanged(nameof(IsBusy));
            }
        }

        public ObservableCollection<FlickrPhotoModel> SearchResults
        {
            get => _searchResults;
            private set
            {
                _searchResults = value;
                NotifyPropertyChanged(nameof(SearchResults));
            }
        }

        public int TotalResults
        {
            get => _totalResults;
            set
            {
                _totalResults = value;
                NotifyPropertyChanged(nameof(TotalResults));
            }
        }

        #endregion Properties

        #region Commands

        public ICommand SearchPhotos => new Command<string>(async (string queryString) =>
        {
            if (string.IsNullOrWhiteSpace(queryString))
            {
                return;
            }

            IsBusy = true;
            SearchResults.Clear();
            _pageIndex = 1;
            FlickrPhotosModel result = await App.FlickrManager.GetPagedPhotoCollectionByText(queryString, _pageIndex);

            _totalPages = result.Pages;
            TotalResults = result.Total;

            foreach (FlickrPhotoModel photoModel in result.FlickrPhotos)
            {
                SearchResults.Add(photoModel);
            }
            IsBusy = false;
        });

        public ICommand GetNextPage => new Command<string>(async (string queryString) =>
        {
            if (_pageIndex >= _totalPages)
            {
                return;
            }

            IsBusy = true;
            _pageIndex += 1;
            FlickrPhotosModel result = await App.FlickrManager.GetPagedPhotoCollectionByText(queryString, _pageIndex, RESULTS_PER_PAGE);
            foreach (FlickrPhotoModel photoModel in result.FlickrPhotos)
            {
                SearchResults.Add(photoModel);
            }
            IsBusy = false;
        });

        #endregion Commands
    }
}
