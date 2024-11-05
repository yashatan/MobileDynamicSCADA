using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppSCADA.Utility;
namespace AppSCADA
{
    public class SCADAAppConfiguration
    {
        List<ControlData> controlDatas;
        public List<ControlData> ControlDatas { get { return controlDatas; } set { controlDatas = value; } }
        public SCADAAppConfiguration() {
        }

    }
}
