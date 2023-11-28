using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using XamarinFlickr.Models;

namespace XamarinFlickr.Services
{
    public class FlickrPhotosManager
    {
        private const string API_KEY = "7800ccd7f349f869798aa502e1262632";
        private const string API_METHOD = "flickr.photos.search";
        private const int API_PER_PAGE = 125;

        public async Task<List<FlickrPhotoModel>> GetPhotoListByText(string queryString)
        {
            var result = new List<FlickrPhotoModel>();

            if (string.IsNullOrWhiteSpace(queryString))
            {
                return result;
            }

            string invariantQueryString = queryString.Trim().ToLowerInvariant();
            using (var httpClient = new HttpClient())
            {
                var getPhoto = await httpClient.GetStringAsync(
                    $"https://api.flickr.com/services/rest/?method={API_METHOD}" +
                    $"&api_key={API_KEY}" +
                    $"&text={invariantQueryString}" +
                    $"&media=photos" +
                    $"&content_types=0,1" + // Photos and Screenshots
                    $"&per_page={API_PER_PAGE}" +
                    $"&format=json&nojsoncallback=1" +
                    $"&extras=description,license,owner_name,views,url_q,url_l,url_o"
                );
                try
                {
                    var flickrModel = JsonSerializer.Deserialize<FlickrPhotosSearchModel>(getPhoto);
                    if (flickrModel.IsOk)
                    {
                        result = flickrModel.PhotosModel?.FlickrPhotos?.ToList() ?? result;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            return result;
        }

        public async Task<FlickrPhotosModel> GetPagedPhotoCollectionByText(string queryString, int page = 1, int perPage = API_PER_PAGE)
        {
            var result = new FlickrPhotosModel();

            if (string.IsNullOrWhiteSpace(queryString))
            {
                return result;
            }

            string invariantQueryString = queryString.Trim().ToLowerInvariant();
            using (var httpClient = new HttpClient())
            {
                var getPhoto = await httpClient.GetStringAsync(
                    $"https://api.flickr.com/services/rest/?method={API_METHOD}" +
                    $"&api_key={API_KEY}" +
                    $"&text={invariantQueryString}" +
                    $"&media=photos" +
                    $"&content_types=0,1" + // Photos and Screenshots
                    $"&per_page={perPage}" +
                    $"&page={page}" +
                    $"&format=json&nojsoncallback=1" +
                    $"&extras=description,license,owner_name,views,url_q,url_l,url_o"
                );
                try
                {
                    var flickrModel = JsonSerializer.Deserialize<FlickrPhotosSearchModel>(getPhoto);
                    if (flickrModel.IsOk)
                    {
                        result = flickrModel.PhotosModel ?? result;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            return result;
        }
    }
}
