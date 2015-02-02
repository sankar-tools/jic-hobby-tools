using System;
using System.Collections;
using System.Text;
using System.Threading;

namespace FireDragan
{
    class FileDownloadQueue
    {
        #region Private Variables
        System.Threading.Thread myThread = null;
        HttpHelper myHttpHelper = null;
        Queue downloadQue = null;
        FileDownloadQueueItem currentDownloadItem;
        #endregion

        #region Properties
        private bool stopDownloading = false;

        public bool StopDownloading
        {
            get { return stopDownloading; }
            set { stopDownloading = value; }
        }

        public IEnumerator List
        {
            get { return downloadQue.GetEnumerator(); }
        }

        #endregion

        #region ctor
        public FileDownloadQueue()
        {
            downloadQue = new Queue();
            myThread = new Thread(new ThreadStart(myWorkerThread));
            myHttpHelper = new HttpHelper();
            myHttpHelper.OnReceiveData += new HttpHelper.OnReceiveDataHandler(myHttpHelper_OnReceiveData);
        }
        #endregion

        public delegate void FileDownloadComplete(object sender, FileDownloadQueueEventArgs args);

        public event FileDownloadComplete DownloadCompleted;

        public void Enqueue(string url, string referrer, string filename)
        {
            downloadQue.Enqueue(new FileDownloadQueueItem(url, referrer, filename));

            if (myThread.ThreadState == ThreadState.Unstarted)
                myThread.Start();

            if (myThread.ThreadState == ThreadState.Suspended)
                myThread.Resume();
        }

        private void myWorkerThread()
        {
            for (; ; )
            {
                if (!stopDownloading)
                {
                    if (downloadQue.Count > 0)
                    {
                        currentDownloadItem = (FileDownloadQueueItem)downloadQue.Dequeue();
                        myHttpHelper.DownloadFileEv(currentDownloadItem.Url,
                            currentDownloadItem.Referrer, currentDownloadItem.Filename);
                    }
                    else
                    {
                        //myThread.slee.Suspend();
                        Thread.Sleep(5000);
                    }
                }
            }
        }

        public void myHttpHelper_OnReceiveData(object sender, HttpHelper.OnReceiveDataEventArgs args)
        {
            if (this.DownloadCompleted != null)
            {
                FileDownloadQueueEventArgs evargs = new FileDownloadQueueEventArgs();
                evargs.File = currentDownloadItem;
                evargs.StatusCode = args.StatusCode;
                evargs.Filesize = args.TotalBytes;

                if (args.Done == true)
                {
                    evargs.IsError = false;
                    evargs.StatusMessage = "Download Successfully";

                    DownloadCompleted(this, evargs);
                }
                else
                {
                    if (args.Error)
                    {
                        evargs.IsError = true;
                        evargs.StatusMessage = args.ErrorMsg;

                        DownloadCompleted(this, evargs);
                    }
                }
            }
        }
    }


    public class FileDownloadQueueEventArgs
    {
        FileDownloadQueueItem file;

        public FileDownloadQueueItem File
        {
            get { return file; }
            set { file = value; }
        }
        System.Net.HttpStatusCode statusCode;

        public System.Net.HttpStatusCode StatusCode
        {
            get { return statusCode; }
            set { statusCode = value; }
        }
        string statusMessage;

        public string StatusMessage
        {
            get { return statusMessage; }
            set { statusMessage = value; }
        }
        bool isError;

        public bool IsError
        {
            get { return isError; }
            set { isError = value; }
        }

        long filesize;

        public long Filesize
        {
            get { return filesize; }
            set { filesize = value; }
        }


    }

    public class FileDownloadQueueItem
    {
        private string filename;

        public string Filename
        {
          get { return filename; }
          set { filename = value; }
        }
        private string referrer;

        public string Referrer
        {
            get { return referrer; }
            set { referrer = value; }
        }
        private string url;

        public string Url
        {
            get { return url; }
            set { url = value; }
        }

        public FileDownloadQueueItem(string url, string referrer, string filename)
        {
            this.filename = filename;
            this.url = url;
            this.referrer = referrer;
        }
    }
}
