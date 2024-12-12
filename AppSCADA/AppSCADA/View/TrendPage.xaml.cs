//using Java.Nio.Channels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
//using static Android.Content.ClipData;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using System.Collections.Specialized;
using LiveChartsCore.SkiaSharpView.Xamarin.Forms;
using LiveChartsCore.SkiaSharpView.VisualElements;
using LiveChartsCore.Drawing;
using LiveChartsCore.Measure;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNet.SignalR.Client.Hubs;

namespace AppSCADA
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TrendPage : ContentPage
    {
        ObservableCollection<AlarmPoint> alarmPoints;
        List<TrendViewSetting> trendviewsettingList;
        List<TagLoggingSetting> tagLoggingSettings;
        List<Tuple<int, ObservableCollection<DateTimePoint>>> TagloggingIdLinesMap;

        public Axis[] XAxes { get; set; } = new Axis[]
        {
            new DateTimeAxis(TimeSpan.FromSeconds(0.5), date => date.ToString("hh:mm:ss"))
        };



        //ObservableCollection<TrendPoint> trendPoints;
        //private static ObservableCollection<DateTimePoint> _values;
        public ObservableCollection<ISeries> Series { get; set; }
        public TrendPage(ObservableCollection<AlarmPoint> palarmPoints)
        {
            InitializeComponent();
            alarmPoints = palarmPoints;
            //lvAlarm.ItemsSource = alarmPoints;
            BindingContext = this;
        }

        public TrendPage()
        {
            InitializeComponent();
            alarmPoints = new ObservableCollection<AlarmPoint>();
            trendviewsettingList = AppSCADAProperties.SCADAAppConfiguration.TrendViewSettings;
            tagLoggingSettings = AppSCADAProperties.SCADAAppConfiguration.TagLoggingSettings;
            TagloggingIdLinesMap = new List<Tuple<int, ObservableCollection<DateTimePoint>>>();

            foreach (var trendviewSetting in trendviewsettingList)
            {
                var chart = new CartesianChart();
                chart.HeightRequest = 200;
                chart.WidthRequest = 200;
                chart.Margin = new Thickness(30, 0, 30, 30);
                ObservableCollection<ISeries> Chart_series = new ObservableCollection<ISeries>();
                foreach (var trend in trendviewSetting.Trends)
                {
                    LineSeries<DateTimePoint> series = new LineSeries<DateTimePoint>();
                    series.GeometryStroke = new SolidColorPaint(new SKColor(trend.ColorStyle.R, trend.ColorStyle.G, trend.ColorStyle.B));
                    series.GeometryFill = new SolidColorPaint(new SKColor(trend.ColorStyle.R, trend.ColorStyle.G, trend.ColorStyle.B));
                    series.GeometrySize = 7;
                    series.Stroke = new SolidColorPaint(new SKColor(trend.ColorStyle.R, trend.ColorStyle.G, trend.ColorStyle.B));
                    series.Fill = null;
                    series.Name = trend.TagLogging.Tag.Name;
                    series.LineSmoothness = 0;
                    var chartValue = new ObservableCollection<DateTimePoint>();
                    TagloggingIdLinesMap.Add(new Tuple<int, ObservableCollection<DateTimePoint>>(trend.TagLogging.Id, chartValue));
                    series.Values = chartValue;
                    Chart_series.Add(series);
                }
                ObservableCollection<Axis> xAxes = new ObservableCollection<Axis>()
                {
                     new DateTimeAxis(TimeSpan.FromSeconds(1), date => date.ToString("hh:mm:ss")){}
                };
                chart.Series = Chart_series;
                chart.XAxes = xAxes;
                //chart.S
                var label = new LabelVisual();
                label.Text = trendviewSetting.Name;
                label.TextSize = 20;
                label.Padding = new Padding(20);
                //chart.ZoomMode = ZoomAndPanMode.X;
                chart.Title = label;
                PageStackLayout.Children.Add(chart);
            }
          //  RequestCurrentTrendPoints();
            BindingContext = this;
        }

        public void RequestCurrentTrendPoints(IHubProxy _hubProxy)
        {
            foreach (var tagloggingsetting in tagLoggingSettings)
            {
                GetTrendPointsSignalR(tagloggingsetting.Id, _hubProxy);
            }

        }

        public void SetCurrentTrendPoints(List<TrendPoint> currenttrendPoints)
        {
            foreach(var trendpoint in currenttrendPoints)
            {
                List<ObservableCollection<DateTimePoint>> chartValueList = TagloggingIdLinesMap.Where(t => t.Item1 == trendpoint.TagLoggingId).Select(t => t.Item2).ToList();
                foreach (var charvalue in chartValueList)
                {
                    charvalue.Add(new DateTimePoint(trendpoint.TimeStamp, trendpoint.Value));
                }
            }
        }

        public TrendPage(ObservableCollection<TrendPoint> trendPoints)
        {
            InitializeComponent();
            alarmPoints = new ObservableCollection<AlarmPoint>();
            BindingContext = this;
        }
        public void AddNewTrendPoint(TrendPoint trendPoint)
        {
            List<ObservableCollection<DateTimePoint>> chartValueList = TagloggingIdLinesMap.Where(t => t.Item1 == trendPoint.TagLoggingId).Select(t => t.Item2).ToList();
            foreach (var charvalue in chartValueList)
            {
                if (charvalue.Count > 0)
                {
                    charvalue.Add(new DateTimePoint(trendPoint.TimeStamp, trendPoint.Value));
                    if (charvalue.Count > AppSCADAProperties.TrendLimitPoints)
                    {
                        charvalue.RemoveAt(0);
                    }
                }

            }

        }
        private async void GetTrendPointsSignalR(int tagloggingid, IHubProxy _hubProxy)
        {
            await _hubProxy.Invoke("GetTrendPoints", tagloggingid);
        }


        private void lvAlarm_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }

}