using System;

namespace AppStudio.Data
{
    /// <summary>
    /// Implementation of the YouTubeSchema class.
    /// </summary>
    public class YouTubeSchema : BindableSchemaBase
    {
        private const string YoutubeWatchBaseUrl = "http://www.youtube.com/watch?v=";

        private string _title;
        private string _summary;
        private string _videoUrl;
        private string _mediaUrl;
        private string _ImageUrl;
        private string _videoId;

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public string Summary
        {
            get { return _summary; }
            set { SetProperty(ref _summary, value); }
        }

        public string VideoUrl
        {
            get { return _videoUrl; }
            set { SetProperty(ref _videoUrl, value); }
        }

        public string MediaUrl
        {
            get { return _mediaUrl; }
            set { SetProperty(ref _mediaUrl, value); }
        }

        public string ImageUrl
        {
            get { return _ImageUrl; }
            set { SetProperty(ref _ImageUrl, value); }
        }

        public string VideoId
        {
            get
            {
                return _videoId;
            }
            set { SetProperty(ref _videoId, value); }
        }

        public string ExternalUrl
        {
            get { return YoutubeWatchBaseUrl + VideoId; }
        }

        public override string DefaultTitle
        {
            get { return Title; }
        }

        public override string DefaultSummary
        {
            get { return Summary; }
        }

        public override string DefaultImageUrl
        {
            get { return ImageUrl; }
        }

        public override string DefaultContent
        {
            get { return Summary; }
        }

        override public string GetValue(string fieldName)
        {
            if (!String.IsNullOrEmpty(fieldName))
            {
                switch (fieldName.ToLower())
                {
                    case "id":
                        return String.Format("{0}", Id);
                    case "title":
                        return String.Format("{0}", Title);
                    case "summary":
                        return String.Format("{0}", Summary);
                    case "videourl":
                        return String.Format("{0}", VideoUrl);
                    case "mediaurl":
                        return String.Format("{0}", MediaUrl);
                    case "imageurl":
                        return String.Format("{0}", ImageUrl);
                    case "videoid":
                        return String.Format("{0}", VideoId);
                    case "externalurl":
                        return String.Format("{0}", ExternalUrl);
                    case "defaulttitle":
                        return String.Format("{0}", DefaultTitle);
                    case "defaultsummary":
                        return String.Format("{0}", DefaultSummary);
                    case "defaultimageurl":
                        return String.Format("{0}", DefaultImageUrl);
                    default:
                        break;
                }
            }
            return String.Empty;
        }
    }
}
