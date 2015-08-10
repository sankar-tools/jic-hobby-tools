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

        public UrlTrackParams(UrlParams oparams)
        {
            Status = "New";
            DownloadedSize = -1;

            Url = oparams.Url;
            Title = oparams.Title;
            ContentType = oparams.ContentType;
            Size = oparams.Size;
        }
    }
}
