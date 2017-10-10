using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWP_Music
{
    public static class StringExt
    {
        public static int RealLength(this string str)
        {
            int len = 0;
            int n = str.Length;
            for (int i = 0; i < n; i++)
            {
                var asc = str.ElementAt(i);
                if (asc < 0 || asc > 127)
                    len += 2;
                else
                    len += 1;
            }
            return len;
        }

        public static string RealSubString(this string str, int length)
        {
            int realLen = 0;
            length = length < str.Length ? length : str.Length;
            for (int i = 0; i < length; i++)
            {
                var asc = str.ElementAt(i);
                if (asc >= 0 && asc <= 127)
                    realLen += 2;
                else
                    realLen += 1;
            }
            realLen = realLen < str.Length ? realLen : str.Length;
            return str.Substring(0, realLen);
        }
    }
}
