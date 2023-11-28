using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace XamarinFlickr.Models
{
    public class FlickrPhotosSearchModel
    {
        [JsonPropertyName("photos")]
        public FlickrPhotosModel PhotosModel { get; set; }
        [JsonPropertyName("stat")]
        public string Status { get; set; }
        [JsonPropertyName("code")]
        public int ErrorCode { get; set; }
        [JsonPropertyName("message")]
        public string ErrorMessage { get; set; }

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
        //[JsonPropertyName("owner")]
        //public string Owner { get; set; }
        //[JsonPropertyName("secret")]
        //public string Secret { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        //[JsonPropertyName("license")]
        //public string License { get; set; }
        [JsonPropertyName("description")]
        public FlickrPhotoDescription Description { get; set; }
        [JsonPropertyName("ownername")]
        public string OwnerName { get; set; }
        [JsonPropertyName("views")]
        public string Views { get; set; }

        // Cropped square thumbnail
        [JsonPropertyName("url_q")]
        public string ImageSourceQ { get; set; }
        [JsonPropertyName("height_q")]
        public int ImageHeightQ { get; set; }
        [JsonPropertyName("width_q")]
        public int ImageWidthQ { get; set; }

        // Large
        [JsonPropertyName("url_l")]
        public string ImageSourceL { get; set; }
        [JsonPropertyName("height_l")]
        public int ImageHeightL { get; set; }
        [JsonPropertyName("width_l")]
        public int ImageWidthL { get; set; }

        // Original
        [JsonPropertyName("url_o")]
        public string ImageSourceO { get; set; }
        [JsonPropertyName("height_o")]
        public int ImageHeightO { get; set; }
        [JsonPropertyName("width_o")]
        public int ImageWidthO { get; set; }

        public bool HasDescription { get => !string.IsNullOrEmpty(Description?.Content); }
        public bool HasLargeUrl { get => !string.IsNullOrWhiteSpace(ImageSourceL); }
        public string ImageSource { get => HasLargeUrl ? ImageSourceL : ImageSourceO; }
    }

    public class FlickrPhotoDescription
    {
        [JsonPropertyName("_content")]
        public string Content { get; set; }
    }
}
