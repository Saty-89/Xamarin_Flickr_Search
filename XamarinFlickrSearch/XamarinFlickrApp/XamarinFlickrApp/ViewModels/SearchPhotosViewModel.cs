using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinFlickr.Models;
using XamarinFlickr.Views;

namespace XamarinFlickr.ViewModels
{
    public class SearchPhotosViewModel : INotifyPropertyChanged
    {
        private List<FlickrPhotoModel> _searchResults = new List<FlickrPhotoModel>();

        public bool IsRunning { get; set; } = false;
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
            IsRunning = true;
            SearchResults = await App.FlickrManager.GetPhotoResults(queryString);
            IsRunning = false;
        });

        #region INotifyPropertyChanged Implementation

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion INotifyPropertyChanged Implementation
    }
}
