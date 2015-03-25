using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using Core.Web;
using System.IO;

namespace OliverBlogCruz
{
    class ThreadController
    {
        int processPageCounter = 0;
        string downloadPath = string.Empty;
        public List<PageProperties> pageCollection = null;
        public string BlogId = string.Empty;

        Thread[] myThreads;
        int maxThreads = 1;

        internal void InitiateProcess()
        {
            downloadPath = GetDownloadPagePath();

            // Process Data Initialize
            processPageCounter = 0;

            // Start Threads
            myThreads = new Thread[maxThreads];

            for (int threadCounter = 0; threadCounter < maxThreads; threadCounter++)
            {
                ThreadStart threadEntry = new ThreadStart(this.DownloadProcess);
                Thread newThread = new Thread(threadEntry);
                newThread.Start();

                myThreads[threadCounter] = newThread;
            }
        }

        private void DownloadProcess()
        {
            PageProperties currentPage = GetNextPage2Process();

            // if all the pages are processed, suspend thread
            if (currentPage == null)
            {
                Thread.Sleep(0);
                
                return;
            }

            string downloadPath = GetDownloadPagePath();
            currentPage.OnCurrentProcessCompleted += new PageProperties.OnCurrentProcessCompleteHandler(currentPage_OnCurrentProcessCompleted);

            string pageStorePath = downloadPath + @"\page_" + currentPage.index.ToString().PadLeft(4, '0') + ".html";
            currentPage.filename = pageStorePath;

            string userAgent = Properties.Settings.Default.UserAgent;

            WebClient client = new WebClient(userAgent, new WebAuth("sankar", "sankar", "sankar"));
            client.OnReceiveData += new WebClient.OnReceiveDataHandler(currentPage.client_OnReceiveData);
            client.DownloadFileEv(currentPage.Url, currentPage.ReferrerUrl, pageStorePath);
        }

        void currentPage_OnCurrentProcessCompleted(object sender, PageProperties.OnCurrentProcessArgs args)
        {
            DownloadProcess();
        }

        private PageProperties GetNextPage2Process()
        {
            if (processPageCounter < pageCollection.Count)
            {
                return pageCollection.ToArray()[processPageCounter++];
            }

            return null;
        }

        private string GetDownloadPagePath()
        {
            string path = Core.IO.Directory.CreateUniqueDirectory(Properties.Settings.Default.StoreBasePath, BlogId);

            Directory.CreateDirectory(path);

            return path;
        }

    }
}
