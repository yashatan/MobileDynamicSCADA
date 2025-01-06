using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppSCADA.Utility;
using static AppSCADA.TagInfo;

namespace AppSCADA
{
    public class SCADAPage : BaseSCADAPage
    {
        public List<ControlData> ControlDatas { get; set; }
        public SCADAPage()
        {
        }
        public SCADAPage(string name)
        {
            Name = name;
            PageType = 0;
        }
    }
}
