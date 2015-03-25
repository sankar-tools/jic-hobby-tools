using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oliva.GenX.DataTier
{
    public class GrabList//: LinkEntity
    {
        //public LinkStatus status;
        //public LinkPriority priority;
        //public DateTime created;
        //public DateTime lastUpdated;
        //public int retryAttempts;
        //public ulong linkSize;
        //public ulong grabbedSize;

        public GrabList(string url, string referer)
        {
            this.url = url;
            this.referrer = referer;
            this.tags = tags;
        }

        /// <summary>
        /// Checks if the provided object is equal to the current Person
        /// </summary>
        /// <param name="obj">Object to compare to the current GrabLinkEntity</param>
        /// <returns>True if equal, false if not</returns>
        public override bool Equals(object obj)
        {
            // Try to cast the object to compare to to be a Person
            var grabLink = obj as GrabList;

            return Equals(grabLink);
        }

        /// <summary>
        /// Returns an identifier for this instance
        /// </summary>
        public override int GetHashCode()
        {
            return url.GetHashCode();
        }

        /// <summary>
        /// Checks if the provided GrabLinkEntity is equal to the current GrabLinkEntity
        /// </summary>
        /// <param name="linkToCompareTo">Person to compare to the current person</param>
        /// <returns>True if equal, false if not</returns>
        public bool Equals(GrabList linkToCompareTo)
        {
            if (linkToCompareTo == null) return false;

            if (string.IsNullOrEmpty(linkToCompareTo.url)) return false;

            return url.Equals(linkToCompareTo.url);
        }
    }
}
