using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presto.Module.Utility
{
    class String
    {
        public static string Convert(string str)
        {
            //str = str.Replace("<br>", "\n");
            return str;
        }

        // 比較
        public static bool Equal(string a, string b)
        {
            a = a.Trim('"');
            b = b.Trim('"');
            if (a == b)
            {
                return true;
            }

            return false;
        }
    }
}
