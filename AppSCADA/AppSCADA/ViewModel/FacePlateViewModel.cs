using System;
using System.Collections.Generic;
using System.Text;
using AppSCADA.Mvvm;
using AppSCADA.Mvvm.Commands;
using AppSCADA.Model;

namespace AppSCADA.ViewModel
{
    public class FacePlateViewModel : BindableBase
    {
        public Motor Motor { get => motor; set { motor = value; OnPropertyChanged(); } }
        Motor motor;

        Device device;
        //private string _motorName;

       

        //public string MotorName
        //{
        //    get { return _motorName; }
        //    set { _motorName = value; OnPropertyChanged(); }
        //}

        //private int _Mode;

        //public int Mode
        //{
        //    get { return _Mode; }
        //    set { _Mode = value; }
        //}
        public DelegateCommand SetStartCommand { get; }
        public DelegateCommand ResetStartCommand { get; }
        public DelegateCommand SetStopCommand { get; }
        public DelegateCommand ResetStopCommand { get; }
        public DelegateCommand SetResetCommand { get; }
        public DelegateCommand ResetResetCommand { get; }

        public FacePlateViewModel(Device device, Motor motor)
        {
            this.motor = motor;
            this.device = device;
            SetStartCommand = new DelegateCommand(SetStartMotor);
            ResetStartCommand = new DelegateCommand(ResetStartMotor);
            SetStopCommand = new DelegateCommand(SetStopMotor);
            ResetStopCommand = new DelegateCommand(ResetStopMotor);
            SetResetCommand = new DelegateCommand(SetResetMotor);
            ResetResetCommand = new DelegateCommand(ResetResetMotor);
        }

        private void ResetStartMotor()
        {


        }

        private void ResetStopMotor()
        {

        }

        private void ResetResetMotor()
        {

        }

        private void SetResetMotor()
        {
            device.Write(true, motor.Name + ".Reset");
            device.Write(false, motor.Name + ".Reset");
        }

        private void SetStopMotor()
        {
            device.Write(true, motor.Name + ".Stop");
            device.Write(false, motor.Name + ".Stop");
        }

        private void SetStartMotor()
        {
            device.Write(true, motor.Name + ".Start");
            device.Write(false, motor.Name + ".Start");

        }
    }
}
