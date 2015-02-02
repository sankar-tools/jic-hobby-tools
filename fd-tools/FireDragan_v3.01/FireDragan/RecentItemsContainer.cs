using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic;

namespace FireDragan
{
    /// <summary>
    /// This class maintains all the collection of the recent items 
    /// 
    /// </summary>
    public class RecentItemsContainer
    {
        string strAppName = "Combo";
        private string strID;
        private int intMaxCount;
        private List<string> lstEntites;
        private List<RecentItemsList> lstEntites1;
        bool  isRemember = false;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strName"></param>
        /// <param name="intCount"></param>
        /// <param name="isRememberRecentLIst"></param>
        public  RecentItemsContainer(string strName, int intCount,bool isRememberRecentLIst)
        {
            strID = strName;
            intMaxCount = intCount;
            lstEntites = new List<string>();
            lstEntites1 = new List<RecentItemsList>();
            isRemember = isRememberRecentLIst;
            if (isRemember)
                OnLoad();
        }
        /// <summary>
        /// 
        /// </summary>
        private void OnLoad()
        {
            string[,] MySettings =Interaction.GetAllSettings(strID, strAppName);

            if (MySettings == null)
                return;
            for (int row = 0; row < MySettings.GetLength(0); row++)
            {
                RecentItemsList RList = new RecentItemsList(MySettings[row, 0], 
                                        Convert.ToInt32(MySettings[row, 1]));
                lstEntites1.Add(RList);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private void Save()
        {
            string[,] MySettings = Interaction.GetAllSettings(strID, strAppName);
            if (MySettings != null &&  MySettings.Length > 0)
            {
                Interaction.DeleteSetting(strID, strAppName, null);
            }
           
            for (int i = 0; i < lstEntites1.Count; i++)
            {
                Interaction.SaveSetting(strID, strAppName, lstEntites1[i].ReceneItems, 
                    lstEntites1[i].ReceneFreq.ToString());
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<RecentItemsList> Get()
        {
            return lstEntites1;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strName"></param>
        public void Add(string strName)
        {

            if ( (lstEntites1.FindAll(lst => lst.ReceneItems == strName).Count >0))
            {
               lstEntites1.Find(lst => lst.ReceneItems == strName).ReceneFreq +=1 ;
               var tempLst = from h in lstEntites1
                             orderby h.ReceneFreq descending
                             select h;
               lstEntites1 = tempLst.ToList();
            }
            else
            {
                var tempLst = from h in lstEntites1
                          orderby h.ReceneFreq descending
                          select h;
                lstEntites1 = tempLst.ToList();
                int intIndex = lstEntites1.FindIndex(dest => dest.ReceneFreq <= 1);
                if (intIndex == -1)   
                    lstEntites1.Add(new RecentItemsList(strName, 1));
                else
                    lstEntites1.Insert (intIndex, new RecentItemsList(strName, 1));
            }
            //lstEntites1.OrderBy(lst => lst.ReceneFreq);
            if (lstEntites1.Count > intMaxCount)
            {
                lstEntites1.RemoveAt(intMaxCount);
            }
            if (isRemember)
                Save();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strName"></param>
        public void Remove(string strName)
        {
            if (lstEntites1.Count == 0)
                return;
            lstEntites.RemoveAll(ff => ff == strName);
            if (isRemember)
                Save();
        }

    }
    /// <summary>
    /// The Entity of Recent Items
    /// </summary>
    public class RecentItemsList
    {
        public RecentItemsList(string Items, int Freq)
        {
            ReceneItems = Items;
            ReceneFreq = Freq;
        }
        public string ReceneItems{get;set;}
        public int ReceneFreq{get;set;}
    }
}
