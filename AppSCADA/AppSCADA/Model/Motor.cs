using System;
using System.Collections.Generic;
using System.Text;
using AppSCADA.Mvvm;

namespace AppSCADA.Model
{
    public class Motor : BindableBase
    {
        #region Field

        private string name;
        private string deviceName;
        private ushort mode;
        private bool start;
        private bool stop;
        private bool runfeedback;
        private bool fault;

        public string Name
        {
            get => name; set
            {
                name = value;
                OnPropertyChanged();
            }
        }
        public string DeviceName
        {
            get => deviceName; set
            {
                deviceName = value;
                OnPropertyChanged();
            }
        }
        public ushort Mode
        {
            get => mode; set
            {
                mode = value;
                OnPropertyChanged();
            }
        }
        public bool Start
        {
            get => start; set
            {
                start = value;
                OnPropertyChanged();
            }
        }
        public bool Stop
        {
            get => stop; set
            {
                stop = value;
                OnPropertyChanged();
            }
        }
        public bool Runfeedback { get => runfeedback; set { runfeedback = value; OnPropertyChanged(); } }
        public bool Fault
        {
            get => fault; set
            {
                fault = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public Motor(string name)
        {
            Name = name;
        }
    }
}
