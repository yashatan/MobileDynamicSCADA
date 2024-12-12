using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppSCADA
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlarmPage : ContentPage
    {
        ObservableCollection<AlarmPoint> alarmPoints;
        public AlarmPage()
        {
            InitializeComponent();
        }

        public AlarmPage(ObservableCollection<AlarmPoint> palarmPoints)
        {
            InitializeComponent();
            alarmPoints = palarmPoints;
            lvAlarm.ItemsSource = alarmPoints;
            BindingContext = this;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var chosenAlarmPoint = button.BindingContext as AlarmPoint;

            if (chosenAlarmPoint != null)
            {
                if (_AlarmACK != null)
                {
                    _AlarmACK(this, new AlarmPointACKEventArgs(chosenAlarmPoint));
                }

            }
        }
        private event EventHandler<AlarmPointACKEventArgs> _AlarmACK;
        public event EventHandler<AlarmPointACKEventArgs> AlarmACK
        {
            add
            {
                _AlarmACK += value;
            }
            remove
            {
                _AlarmACK -= value;
            }
        }

    }
    public class AlarmPointACKEventArgs : EventArgs
    {
        public AlarmPoint AlarmPoint { get; set; }
        public AlarmPointACKEventArgs(AlarmPoint alarmPoint)
        {
            AlarmPoint = alarmPoint;
        }
    }
}