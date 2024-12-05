using System;
using System.Collections.Generic;
using System.Text;

namespace AppSCADA
{
    public class AlarmPoint
    {
        private int _Id;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string text;

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public enum AlarmType
        {
            Warning,
            Error
        }

        private AlarmType type;

        public AlarmType Type
        {
            get { return type; }
            set { type = value; }
        }

        private DateTime timeStamp;

        public DateTime TimeStamp
        {
            get { return timeStamp; }
            set { timeStamp = value; }
        }

        public AlarmPoint()
        {

        }
    }
}
