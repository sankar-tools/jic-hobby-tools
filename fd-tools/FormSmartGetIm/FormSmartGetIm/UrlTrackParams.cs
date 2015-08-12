using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SansTech.Net.Http;

namespace FormSmartGetIm
{
    public class UrlTrackParams : UrlParams
    {
        public string Id { get; set; }
        public string Status { get; set; }
        public long DownloadedSize { get; set; }
        public string Source { get; set; }

        public UrlTrackParams()
        { }

        public UrlTrackParams(UrlParams oparams)
        {
            Status = "New";
            DownloadedSize = -1;

            Url = oparams.Url;
            Title = oparams.Title;
            ContentType = oparams.ContentType;
            Size = oparams.Size;
        }

        public UrlTrackParams(ImageLinks oparams)
        {
            //Link = oparams.Link;
            Url = oparams.Link;
            Source = oparams.Image;
            Size = oparams.Size;
            //Height = oparams.Height;
            //Width = oparams.Width;
            //Filename = oparams.Filename;
            Status = "New";
        }
    }

    //public class ImageLinkParams : ImageLinks
    //{
    //    public string Status { get; set; }

    //    public ImageLinkParams(ImageLinks oparams)
    //    {
    //        Link = oparams.Link;
    //        Image = oparams.Image;
    //        Size = oparams.Size;
    //        Height = oparams.Height;
    //        Width = oparams.Width;
    //        Filename = oparams.Filename;
    //        Status = "New";
    //    }
    //}
}
