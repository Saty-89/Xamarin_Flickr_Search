using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using XamarinFlickr.Models;

namespace XamarinFlickr.ViewModels
{
    public class PhotoDetailViewModel : INotifyPropertyChanged
    {
        private FlickrPhotoModel photoModel;

        public FlickrPhotoModel PhotoModel
        {
            get => photoModel;
            set
            {
                photoModel = value;
                NotifyPropertyChanged(nameof(PhotoModel));
            }
        }

        #region INotifyPropertyChanged Implementation

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion INotifyPropertyChanged Implementation
    }
}
