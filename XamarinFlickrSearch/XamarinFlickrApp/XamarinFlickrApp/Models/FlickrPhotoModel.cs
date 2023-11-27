using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace XamarinFlickr.Models
{
    public class FlickrModel
    {
        [JsonPropertyName("photos")]
        public FlickrPhotosModel PhotosModel { get; set; }
        [JsonPropertyName("stat")]
        public string Status { get; set; }
        public bool IsOk { get => !string.IsNullOrWhiteSpace(Status) && Status.Equals("ok", StringComparison.InvariantCultureIgnoreCase); }
    }

    public class FlickrPhotosModel
    {
        [JsonPropertyName("page")]
        public int Page { get; set; }
        [JsonPropertyName("pages")]
        public int Pages { get; set; }
        [JsonPropertyName("perpage")]
        public int PerPage { get; set; }
        [JsonPropertyName("total")]
        public int Total { get; set; }
        [JsonPropertyName("photo")]
        public IEnumerable<FlickrPhotoModel> FlickrPhotos { get; set; }
    }

    public class FlickrPhotoModel
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("owner")]
        public string Owner { get; set; }
        [JsonPropertyName("secret")]
        public string Secret { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("license")]
        public string License { get; set; }
        [JsonPropertyName("description")]
        public FlickrPhotoDescription Description { get; set; }
        [JsonPropertyName("ownername")]
        public string OwnerName { get; set; }
        [JsonPropertyName("views")]
        public string Views { get; set; }
        [JsonPropertyName("url_s")]
        public string ImageSourceS { get; set; }
        [JsonPropertyName("height_s")]
        public int ImageHeightS { get; set; }
        [JsonPropertyName("width_s")]
        public int ImageWidthS { get; set; }
        [JsonPropertyName("url_l")]
        public string ImageSourceL { get; set; }
        [JsonPropertyName("height_l")]
        public int ImageHeightL { get; set; }
        [JsonPropertyName("width_l")]
        public int ImageWidthL { get; set; }
    }

    public class FlickrPhotoDescription
    {
        [JsonPropertyName("_content")]
        public string Content { get; set; }
    }
}
