using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PZ_10
{
    public class NotePadStatus
    {
        public double FontSize { get; set; }
        public string Txt { get; set; }
        public FontWeight FontWeight { get; set; }
        public FontStyle FontStyle { get; set; }

        public NotePadStatus(double fontsize, string txt, FontWeight fontweight, FontStyle fontstyle) 
        {
            FontSize = fontsize;
            Txt = txt;
            FontWeight = fontweight;
            FontStyle = fontstyle;
        }
        public NotePadStatus()
        {
            FontSize = 14;
            FontStyle = FontStyles.Normal;
            FontWeight = FontWeights.Normal;
        }
    }
}
