using AppSCADA.Utility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppSCADA
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TagLoggingPage : ContentPage
    {
        ObservableCollection<TagLoggingSetting> tagLoggingSettings;
        ObservableCollection<TrendPoint> tagLoggingData;
        public TagLoggingPage()
        {
            InitializeComponent();
            InitData();
            BindingContext = this;
        }

        private void InitData()
        {
            tagLoggingSettings = new ObservableCollection<TagLoggingSetting>();
            tagLoggingData = new ObservableCollection<TrendPoint>();
            foreach (var tagloggingsetting in AppSCADAProperties.SCADAAppConfiguration.TagLoggingSettings)
            {
                tagLoggingSettings.Add(tagloggingsetting);
            }
            TagLoggingPicker.ItemsSource = tagLoggingSettings;
            lvData.ItemsSource = tagLoggingData;
        }

        public void SetTagLoggingDatas(IEnumerable<TrendPoint> ptrendPoints)
        {
            tagLoggingData.Clear();
            foreach (var trendpoint in ptrendPoints)
            {
                tagLoggingData.Add(trendpoint);
            }
        }

        private async void btnGetData_Clicked(object sender, EventArgs e)
        {
            TagLoggingSetting chosenTag = (TagLoggingPicker.SelectedItem as TagLoggingSetting);
            if (chosenTag != null)
            {
                DateTime beginDate = BeginDatePicker.Date + BeginTimePicker.Time;
                DateTime endDate = EndDatePicker.Date + EndTimePicker.Time;
                AppSCADAController.Instance.RequestTagLoggingData(chosenTag.Id, beginDate, endDate);
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Get Data Fail", "Plese select a tag", "OK");
            }
        }

        private void btnClearData_Clicked(object sender, EventArgs e)
        {
            tagLoggingData.Clear();
        }
    }
}