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
        private List<AlarmPoint> currentAlarmPoints;

        public List<AlarmPoint> CurrentAlarmPoints
        {
            get { return currentAlarmPoints; }
            set { currentAlarmPoints = value; }
        }
        List<TrendViewSetting> trendViewSettings;
        public List<TrendViewSetting> TrendViewSettings
        {
            get { return trendViewSettings; }
            set { trendViewSettings = value; }
        }
        public SCADAAppConfiguration()
        {
        }

    }
}
