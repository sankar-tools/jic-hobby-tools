using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SansTech
{
	public static class ObjectEx
	{
        public static string ToEmptyString(this object o)
        {
            if (o == null)
                return String.Empty;

            return o.ToString();
        }
	}
}
