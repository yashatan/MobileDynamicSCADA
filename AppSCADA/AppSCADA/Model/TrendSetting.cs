using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppSCADA.Utility;

namespace AppSCADA
{
    public class TrendSetting
    {
        public TrendSetting()
        {
            Name = "Trend_";
            ColorStyle = new ColorRGB();
            ColorStyle.R = 0;
            ColorStyle.G = 0;
            ColorStyle.B = 0;
        }
        public TrendSetting(int number)
        {
            Name = $"Trend_{number}";
            ColorStyle = new ColorRGB();
            ColorStyle.R = 0;
            ColorStyle.G = 0;
            ColorStyle.B = 0;
        }
        public int Id { set; get; }
        public string Name { set; get; }
        public TagLoggingSetting TagLogging { set; get; }
        public ColorRGB ColorStyle { set; get; }
    }

}
