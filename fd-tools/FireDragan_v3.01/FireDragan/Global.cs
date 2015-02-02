using System;
using System.Collections.Generic;
using System.Text;

namespace FireDragan
{

    public delegate void UriSelected(object sender, UriSelectedEventArgs e);

    public delegate void NavigatorReset(object sender, EventArgs e);

    public delegate void StatusChanged(object sender, StatusEventArgs args);

    public enum GrabPriority
    { 
        Immediate = 0,
        None = -1,
        High = 1,
        Medium = 2,
        Low = 3
    }

    interface Global
    {
    }
}
