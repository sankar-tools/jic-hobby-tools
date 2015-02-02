using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace FireDragan
{
    class SessionManager 
    {
        private SessionManager()
        {
            _session = new Session();    
        }

        private Session _session = null;

        public Session Session
        {
            get { return _session; }
            set { _session = value; }
        }

        // Get all the session details
        public DataTable GetSessions()
        {
            string constr = SettingsHelper.Current.IndentityDB;
            string cmdstr = "select * from sessionview";

            SqlConnection cn = new SqlConnection(constr);
            SqlDataAdapter adp = new SqlDataAdapter(cmdstr, constr);
            DataSet ds = new DataSet();

            try
            {
                cn.Open();
                adp.Fill(ds);

            }
            finally            
            {

                cn.Close();
                adp.Dispose();
                cn.Dispose();
            }
            
            return ds.Tables[0];
        }

        public void LoadSession(int ID)
        {
            _session = new Session(ID);        
        }

        private static SessionManager _instance;

        /// <summary>
        /// An object for locking the thread, when needed
        /// </summary>
        private static object _lockObject = new object();

        /// <summary>
        /// Obtains the current instance of the session manager class.
        /// </summary>
        /// <remarks>
        /// If there is no instance of the session manager class, one will be created
        /// </remarks>
        public static SessionManager Current
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lockObject)
                    {
                        if (_instance == null)
                            _instance = new SessionManager();
                    }
                }
                return _instance;
            }
        }

    }

    class Session
    {
        int _lastSaveSize = 0;
        int _nextindex = 0;

        private int _id = 0;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _desc = string.Empty;

        public string Desc
        {
            get { return _desc; }
            set { _desc = value; }
        }
        private ArrayList _sessionLinks = null;
        private ArrayList _sessionListStatus = null;

        public ArrayList SessionLinks
        {
            get { return (_sessionLinks); }
        }

        private const int __bufferSizeConst = 15;

        private int _bufferSize = __bufferSizeConst;

        public int BufferSize
        {
            get { return _bufferSize; }
            set { _bufferSize = value; }
        }

        public Session()
        {
            _sessionLinks = new ArrayList();
        }

        public Session(int ID)
        {
            LoadSessionDetails(ID);
        }

        // Load session details for the given ID
        private void LoadSessionDetails(int ID)
        { }

        // Save session details to db
        public void Save()
        {
            string constr = SettingsHelper.Current.IndentityDB;
            string cmdstr = "insert into session (sessionDesc) Values ('{0}')";

            SqlConnection cn = new SqlConnection(constr); 
            SqlCommand cmd = new SqlCommand(String.Format(cmdstr, DateTime.Now.ToString()), cn);

            cn.Open();
            cmd.ExecuteNonQuery();

            cmdstr = "select max(sessionID) from session";
            cmd.CommandText = cmdstr;

            int id = Convert.ToInt32(cmd.ExecuteScalar());

            cmdstr = "insert into SessionDetails (SessionID, SessionUrl, Visited) Values ({0}, '{1}', {2})";

            for (int i = 0; i < _sessionLinks.Count; i++)
            {
                SessionLink link = (SessionLink)_sessionLinks[i];

                string newcmdstr = string.Format(cmdstr, id, link.Link, (link.Visited? "1":"0"));

                cmd.CommandText = newcmdstr;

                cmd.ExecuteScalar();
            }

            cmd.Dispose();
            cn.Close();
            cn.Dispose();

            _lastSaveSize = _sessionLinks.Count;
        }

        public void Reset()
        {
            _id = 0;
            _sessionLinks.Clear();
        }

        public void Delete()
        { 
            
        }

        public void AddLink(string Url)
        {
            AddLink(Url, false);
        }

        private void CheckSaveSession()
        {
            if (_sessionLinks.Count > _bufferSize + _lastSaveSize)
                Save();
        }

        public void AddLink(string Url, bool Visited)
        {
            int found = IndexOf(Url);

            if (found >= 0)
            {
                if(Visited) 
                    ((SessionLink) _sessionLinks[found]).Visited = true;
            }
            else
            {
                _sessionLinks.Add(new SessionLink(Url, Visited));
                CheckSaveSession();
            }
        }

        public int IndexOf(string Url)
        {
            int foundIndex = -1;

            //SessionLink[] sessionLinks = (SessionLink[])_sessionLinks.ToArray();

            for (int i = 0; i < _sessionLinks.Count; i++)
            {
                SessionLink link = (SessionLink)_sessionLinks[i];
                if (link.Link == Url)
                {
                    foundIndex = i;
                    break;
                }
            }
            return foundIndex;
        }

        public string GetNextLink(bool unvisited)
        {
            string nextLink = string.Empty;

            if (!unvisited)
            {
                nextLink = ((SessionLink)_sessionLinks.ToArray()[_nextindex++]).Link;
            }
            else
            {
                SessionLink[] sessionLinks = (SessionLink[]) _sessionLinks.ToArray();

                for(int i=0; i<sessionLinks.Length; i++)
                { 
                    if(sessionLinks[i].Visited == false)
                        nextLink = sessionLinks[i].Link;
                }
            }

            return nextLink;
        }
    }

    public class SessionLink
    {
        private string _link;

        public string Link
        {
            get { return _link; }
            set { _link = value; }
        }
        private bool _visited;

        public bool Visited
        {
            get { return _visited; }
            set { _visited = value; }
        }

        public SessionLink(string Url, bool Visited)
        {
            this.Visited = Visited;
            this.Link = Url;
        }
    }
}
