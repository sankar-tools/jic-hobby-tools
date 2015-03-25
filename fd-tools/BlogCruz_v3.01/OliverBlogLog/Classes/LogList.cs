using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace OliverBlogLog
{
    public class Log
    {
        public static Dictionary<string, LogItem> Entries = new Dictionary<string,LogItem>();

        public static LogItem GetLogInfo(string blogId)
        {
            return Entries[blogId];
        }

        internal static void FillEntries(System.Data.DataSet ds)
        {
            DataTable logList = ds.Tables["BlogList"];
            DataTable logSessions = ds.Tables["BlogTrack"];
            DataTable logCounters = ds.Tables["BlogCounters"];
            DataTable logStats = ds.Tables["BlogStats"];

            DataRelation relation = null;

            try
            {
                relation = new DataRelation("BlogID", logList.Columns["BlogId"], logSessions.Columns["BlogId"]);
                ds.Relations.Add(relation);
            }
            catch (Exception ex)
            { 
                // relation may fail due to constraints failure
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }

            foreach (DataRow row in logList.Rows)
            {
                string blogId = row["BlogId"] as string;

                LogItem item = null;

                if (!Entries.TryGetValue(blogId, out item))
                {
                    item = new LogItem();
                    Entries.Add(blogId, item);
                    
                }

                item.BlogId = blogId;
                item.Link = row["Url"] as string;
                item.Rating = (int) row["Rate"];
                item.MaxIndex = (int)row["MaxThreads"];
                item.Keywords = (string)row["Keys"];
                item.TotalThreads = (int)row["MaxThreads"];
                item.Sessions = new List<LogListSession>();

                int minIndex = 0;
                int maxIndex = 0;
                int runningIndex =0;

                foreach(DataRow row1 in row.GetChildRows(relation))
                {
                    LogListSession session = new LogListSession();
                    session.SessionId = (long)row1["SessionId"];
                    session.StartIndex = (int) row1["startIndex"];
                    session.EndIndex = (int)row1["endIndex"];
                    session.StepIndex = (int)row1["step"];
                    session.Session = (DateTime)row1["Created"];
                    session.Images = (int)row1["images"];

                    if(runningIndex == 0)
                    {
                        minIndex = session.StartIndex;
                        maxIndex = session.EndIndex;
                    }

                    if (session.StartIndex < minIndex)
                        minIndex = session.StartIndex;

                    if (session.EndIndex > maxIndex)
                        maxIndex = session.EndIndex;

                    item.Sessions.Add(session);
                }

                item.MinIndex = minIndex;
                item.MaxIndex = maxIndex;

                Entries[blogId] =  item;
            }

            #region Fill BlogCounters
            // Process BlogCounters
            if (logCounters == null) return; // db fetch failed - do not fill categories
            foreach (DataRow counterRow in logCounters.Rows)
            {
                string blogId = GetBlogID4Category(counterRow["category"] as string);
                if (blogId != null)
                {
                    LogItem item = null;
                    if (Entries.TryGetValue(blogId, out item))
                    {
                        string status = (counterRow["status"] as string).ToLower();
                        int count = (int) counterRow["counts"];

                        switch (status)
                        { 
                            case "ok":
                            case "done":
                                item.DoneCounter += count;
                                break;

                            case "new":
                                item.NewCounter += count;
                                break;

                            case "hold":
                                item.HoldCounter += count;
                                break;

                            case "notfound":
                                item.BadCounter += count;
                                break;

                            default:
                                item.OtherCounter += count;
                                break;
                        }


                    }
                }
            }
            #endregion

            #region Fill BlogStats
            if (logStats == null) return;
            foreach (DataRow statsRow in logStats.Rows)
            {
                string blogId = GetBlogID4Category(statsRow["category"] as string);
                if (blogId != null)
                {
                    LogItem item = null;
                    if (Entries.TryGetValue(blogId, out item))
                    {
                        if (item.Stats == null) item.Stats = new Dictionary<string, LogStats>();

                        string url = statsRow["site"] as string;
                        string urlKey = string.Empty;

                        if (string.IsNullOrEmpty(url))
                            urlKey = "NotAvailable";
                        else
                        {
                            urlKey = Core.GetHostName(url);
                            UriParsing components = UriParsing.Parse(urlKey);

                            if (components != null)
                                urlKey = components.PrimaryDomain;
                        }

                        LogStats stats = null;

                        // if key does not exist, add new entry
                        if (!item.Stats.TryGetValue(urlKey, out stats))
                        {
                            stats = new LogStats();
                            item.Stats.Add(urlKey, stats);
                        }

                        stats.Domain = urlKey;
                        string status = (statsRow["status"] as string).ToLower();
                        int count = (int)statsRow["nos"];

                        switch (status)
                        {
                            case "ok":
                            case "done":
                                stats.Done += count;
                                break;

                            case "new":
                                stats.New += count;
                                break;

                            case "hold":
                                stats.Hold += count;
                                break;

                            case "notfound":
                                stats.NotFound += count;
                                break;

                            default:
                                stats.Others += count;
                                break;
                        }

                        item.Stats[urlKey] = stats;
                    }
                }
            }


            #endregion
        }

        private static string GetBlogID4Category(string p)
        {
            if (p == null) return null ;

            int marker = p.IndexOf(',');
            string blogId = null;

            if (marker > 0)
            {
                blogId = p.Substring(0, marker);
            }

            return blogId;
        }
    }

    public class LogItem
    {
        public string BlogId;
        public string Link;
        public int TotalThreads;
        public string Keywords;
        public DateTime Created;
        public DateTime Modified;
        public DateTime Grabbed;
        public int Rating;
        public int MinIndex;
        public int MaxIndex;

        public List<LogListSession> Sessions;
        public Dictionary<string, LogStats> Stats;

        public int NewCounter;
        public int DoneCounter;
        public int BadCounter;
        public int HoldCounter;
        public int OtherCounter;
    }

    public class LogListSession
    {
        public long SessionId;
        public DateTime Session;
        public int StartIndex;
        public int EndIndex;
        public int StepIndex;
        public int Images;
    }

    public class LogStats
    {
        public string Domain;
        public int New;
        public int Done;
        public int Hold;
        public int NotFound;
        public int Others;

    }
}
