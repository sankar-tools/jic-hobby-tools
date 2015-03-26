using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace fd.lib.ui.common
{
    public class ListViewItemComparer : IComparer
    {
        private int col;
        public SortOrder Sort = SortOrder.None;
        public SortAs SortAs = SortAs.Text;

        public ListViewItemComparer()
        {
            col = 0;
        }
        public ListViewItemComparer(int column)
        {
            col = column;
        }
        public int Compare(object x, object y)
        {
            int retValue = 0;
            try
            {
                switch (SortAs)
                {
                    case SortAs.Text:
                        if (Sort == SortOrder.Ascending)
                            retValue = String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
                        else
                            retValue = String.Compare(((ListViewItem)y).SubItems[col].Text, ((ListViewItem)x).SubItems[col].Text);

                        break;

                    case SortAs.Integer:
                        if (Sort == SortOrder.Ascending)
                            retValue = (Convert.ToInt32(((ListViewItem)x).SubItems[col].Text) -
                                Convert.ToInt32(((ListViewItem)y).SubItems[col].Text));
                        else
                            retValue = (Convert.ToInt32(((ListViewItem)y).SubItems[col].Text) -
                                Convert.ToInt32(((ListViewItem)x).SubItems[col].Text));

                        break;

                    case SortAs.Date:
                        if (Sort == SortOrder.Ascending)
                            retValue = DateTime.Compare(Convert.ToDateTime(((ListViewItem)x).SubItems[col].Text),
                                Convert.ToDateTime(((ListViewItem)y).SubItems[col].Text));
                        else
                            retValue = DateTime.Compare(Convert.ToDateTime(((ListViewItem)y).SubItems[col].Text),
                                Convert.ToDateTime(((ListViewItem)x).SubItems[col].Text));

                        break;

                }
            }
            catch (Exception)
            { }

            return retValue;
        }
    }

    public enum SortAs
    {
        Integer,
        Date,
        Text
    }
}
