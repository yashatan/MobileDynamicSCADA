using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSCADA
{
    public class TagLoggingSetting
    {
        public TagLoggingSetting()
        {
            LoggingCycle = CycleType.em1Sec;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public TagInfo Tag { get; set; }

        public enum CycleType
        {
            em1Sec = 0,
            em2Sec,
            em5Sec,
            em10Sec,
            em1min,
            em5min,
            em10min,
            em1hour
        }

        public CycleType LoggingCycle { get; set; }
        public double currentDuration { get; set; }
        public double GetTimeCycle()
        {
            double timetowait;
            switch (LoggingCycle)
            {
                case CycleType.em1Sec:
                    timetowait = 1.0;
                    break;
                case CycleType.em2Sec:
                    timetowait = 2.0;
                    break;
                case CycleType.em5Sec:
                    timetowait = 5.0;
                    break;
                case CycleType.em10Sec:
                    timetowait = 10.0;
                    break;
                case CycleType.em1min:
                    timetowait = 60.0;
                    break;
                case CycleType.em5min:
                    timetowait = 60.0 * 5;
                    break;
                case CycleType.em10min:
                    timetowait = 60.0 * 10;
                    break;
                case CycleType.em1hour:
                    timetowait = 60.0 * 60;
                    break;
                default:
                    timetowait = 60.0;
                    break;
            }
            return timetowait;
        }
    }
}
