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
        // TODO: encrypt
        const string API_KEY = "7800ccd7f349f869798aa502e1262632";
        const string API_METHOD = "flickr.photos.search";
        const string API_PER_PAGE = "200";

        public async Task<List<FlickrPhotoModel>> GetPhotoResults(string queryString)
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
                    $"https://api.flickr.com/services/rest/?method={API_METHOD}&api_key={API_KEY}&text={invariantQueryString}" +
                    $"&per_page={API_PER_PAGE}&format=json&nojsoncallback=1&extras=description,license,owner_name,views,url_s,url_l"
                );
                try
                {
                    result = JsonSerializer.Deserialize<FlickrModel>(getPhoto)?.PhotosModel?.FlickrPhotos?.ToList() ?? result;
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
