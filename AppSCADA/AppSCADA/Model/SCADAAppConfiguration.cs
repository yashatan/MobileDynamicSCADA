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
        List<TagLoggingSetting> tagLoggingSettings;
        public List<TagLoggingSetting> TagLoggingSettings
        {
            get { return tagLoggingSettings; }
            set { tagLoggingSettings = value; }
        }
        private List<TagInfo> tagInfos;
        public List<TagInfo> TagInfos
        {
            get { return tagInfos; }
            set { tagInfos = value; }
        }
        List<SCADAPage> scadaPages;
        public List<SCADAPage> SCADAPages
        {
            get { return scadaPages; }
            set { scadaPages = value; }
        }
        public SCADAAppConfiguration()
        {
        }
        public int MainPageId;
    }
}
