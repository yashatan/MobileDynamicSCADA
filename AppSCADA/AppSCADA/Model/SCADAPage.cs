using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppSCADA.Utility;

namespace AppSCADA
{
    public class SCADAPage
    {
        public List<ControlData> ControlDatas { get; set; }
        public SCADAPage()
        {
        }
        public int Id { get; set; }
        public int PageType { get; set; }
        public string Name { get; set; }
    }
}
