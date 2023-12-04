using System;
using System.Collections.Generic;
using System.Text;
using AppSCADA.Mvvm;
using AppSCADA.Mvvm.Commands;
using AppSCADA.Model;
using Xamarin.Forms;
using System.Globalization;

namespace AppSCADA.ViewModel
{
    public class MainPageViewModel : BindableBase
    {
        Model.Device myDevice;
        public Model.Device MyDevice { get => myDevice; set { myDevice = value; OnPropertyChanged(); } }

        public DelegateCommand<Motor> OpenFacePlateCommand { get; }
        public MainPageViewModel()
        {
            //MyDevice = new Model.Device("PLC", "192.168.1.50");
            MyDevice = new Model.Device("PLC", "192.168.1.201");
            OpenFacePlateCommand = new DelegateCommand<Motor>((p)=>OpenFacePlate(p));
        }

        private  void OpenFacePlate(Motor motor)
        {
            Console.WriteLine(motor.Name);
            Application.Current.MainPage.Navigation.PushAsync(new FacePlate(MyDevice, motor));
        }

    }

    public class MotorImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var status = (bool)value;
            if (status)
            {
                //var source = ImageSource.FromResource("AppSCADA.image.pump_side_green.gif") ;
                //return source;
                return "pump_side_green.gif";
            }
            else
            {
                //return ImageSource.FromResource("AppSCADA.image.pump_side_grey.gif");
                return "pump_side_grey.gif";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class LevelProgressConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var status = (int)value;
            float result = (float)((float)status / 100.0);
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class StatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var status = (bool)value;
            if (status)
            {
                //return ImageSource.FromResource("AppSCADA.image.GreenCircle.gif");
                return "GreenCircle.gif";
            }
            else
            {
                //return ImageSource.FromResource("AppSCADA.image.GreyCircle.png");
                return "GreyCircle.png";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
