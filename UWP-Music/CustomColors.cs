using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace UWP_Music
{
    public class CustomColors
    {
        public static Color TitleBackGroundColor
        {
            get
            {
                return new Color() { A = 255, R = 189, G = 47, B = 46 };
            }
        }

        public static Color TitleInactiveColor
        {
            get
            {
                return new Color() { A = 255, R = 181, G = 113, B = 114 };
            }
        }

        public static Color TitleHoverBackgroundColor
        {
            get
            {
                return new Color() { A = 255, R = 230, G = 17, B = 35 };
            }
        }

        public static Color TitlePressedBackgroundColor
        {
            get
            {
                return new Color() { A = 255, R = 243, G = 112, B = 120 };
            }
        }
    }
}
