﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFlickr.Models;

namespace XamarinFlickr.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InfiniteScrollPhotoPage : ContentPage
    {
        public InfiniteScrollPhotoPage()
        {
            InitializeComponent();
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            var button = sender as View;
            if (button != null)
            {
                FlickrPhotoModel photoModel = button.BindingContext as FlickrPhotoModel;
                if (photoModel != null)
                {
                    await Navigation.PushAsync(new PhotoDetailPage(photoModel));
                }
            }
        }
    }
}