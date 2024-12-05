using System;
using System.Collections.Generic;
using System.Text;

namespace AppSCADA
{
    public class TrendPoint
    {
        public int Id { get; set; }

        public double Value { get; set; }
        public DateTime TimeStamp { get; set; }

        public int TagLoggingId { get; set; }
        public TrendPoint(int tagLoggingId, double value, DateTime dateTime)
        {
            this.TagLoggingId = tagLoggingId;
            this.Value = value;
            this.TimeStamp = dateTime;
        }
        public TrendPoint()
        {
            Value = 0.0;
        }

    }
}
