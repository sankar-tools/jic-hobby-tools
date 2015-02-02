using System;
using System.Collections.Generic;
using System.Text;

namespace FireDragan
{
    public class SeriesLinks
    {
        string pattern;
        int startIndex = -1;
        int endIndex = -1; 
        int currentIndex;

        bool padding = true;
        char padWord = '0';
        int padLength = 2;

        SeriesLinkManager.SerialDirection direction = SeriesLinkManager.SerialDirection.Forward;

        public string Pattern
        {
            get { return pattern;  }
            set { pattern = value; }
        }

        public int Start
        {
            get { return startIndex; }
            set { startIndex = value; }
        }

        public int End
        {
            get { return endIndex; }
            set { endIndex = value; }
        }

        public int Current
        {
            get { return currentIndex; }
            set { currentIndex = value; }
        }

        public bool IsPadded
        {
            get { return padding; }
            set { padding = value; }
        }

        public char PadWith
        {
            get { return padWord; }
            set { padWord = value; }
        }

        public int PadLength
        {
            get { return padLength; }
            set { padLength = value; }
        }

        public SeriesLinkManager.SerialDirection Direction
        {
            get { return direction; }
            set { direction = value; }
        }

        public string GetNextSerialUrl()
        {
            string nextUri = string.Empty;

            if (this.Pattern.IndexOf("[i]") > 0)
            {

                if (this.IsPadded)
                {
                    nextUri = this.Pattern.Replace("[i]", this.Current.ToString().PadLeft(this.PadLength, this.PadWith));
                }
                else
                {
                    nextUri = this.Pattern.Replace("[i]", this.Current.ToString());
                }

                if (this.Direction == SeriesLinkManager.SerialDirection.Forward)
                {
                    this.Current++;
                    this.End = this.Current;
                }
                else
                {
                    this.Current--;
                    this.Start = this.Current;
                }
            }
            else
            {
                throw new Exception("Invalid format");
            }

            return nextUri;
        }
    }

    public class SeriesLinkManager
    {
        public enum SerialDirection
        {
            Forward,
            Backward
        }

        private SeriesLinks serial = new SeriesLinks();

        //public SeriesLinkManager(SeriesLinks serial)
        //{
        //    this.serial = serial;
        //}

        public SeriesLinks Serial
        {
            get { return serial; }
            set { serial = value; }
        }

        
    }
}
