using Java.Nio.Channels;
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
using static Android.Content.ClipData;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using System.Collections.Specialized;
using LiveChartsCore.SkiaSharpView.Xamarin.Forms;

namespace AppSCADA
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        ObservableCollection<AlarmPoint> alarmPoints;
        List<TrendViewSetting> trendviewsettingList;
        List<Tuple<int, ObservableCollection<DateTimePoint>>> TagloggingIdLinesMap;
        public Axis[] XAxes { get; set; } = new Axis[]
        {
            new DateTimeAxis(TimeSpan.FromSeconds(0.5), date => date.ToString("hh:mm:ss"))
        };



        ObservableCollection<TrendPoint> trendPoints;
        private static ObservableCollection<DateTimePoint> _values;
        public ObservableCollection<ISeries> Series { get; set; }
        public Page1(ObservableCollection<AlarmPoint> palarmPoints)
        {
            InitializeComponent();
            alarmPoints = palarmPoints;
            //lvAlarm.ItemsSource = alarmPoints;
            BindingContext = this;
        }

        public Page1(List<TrendViewSetting> trendViewSettings)
        {
            InitializeComponent();
            alarmPoints = new ObservableCollection<AlarmPoint>();
            trendviewsettingList = trendViewSettings;
            TagloggingIdLinesMap = new List<Tuple<int, ObservableCollection<DateTimePoint>>>();
            foreach (var trendviewSetting in trendviewsettingList)
            {
                var chart = new CartesianChart();
                //chart.
                chart.HeightRequest = 200;
                chart.WidthRequest = 200;
                chart.Margin = new Thickness(0, 50, 0, 0);
                ObservableCollection<ISeries> Chart_series = new ObservableCollection<ISeries>();
                foreach (var trend in trendviewSetting.Trends)
                {
                    LineSeries<DateTimePoint> series = new LineSeries<DateTimePoint>();
                    series.GeometryFill = new SolidColorPaint(new SKColor(trend.ColorStyle.R, trend.ColorStyle.G, trend.ColorStyle.B));
                    series.Stroke = new SolidColorPaint(new SKColor(trend.ColorStyle.R, trend.ColorStyle.G, trend.ColorStyle.B));
                    series.Fill = null;
                    var chartValue = new ObservableCollection<DateTimePoint>();
                    TagloggingIdLinesMap.Add(new Tuple<int, ObservableCollection<DateTimePoint>> (trend.TagLogging.Id, chartValue));
                    series.Values = chartValue;
                    Chart_series.Add(series);
                }
                ObservableCollection<Axis> xAxes = new ObservableCollection<Axis>()
                {
                     new DateTimeAxis(TimeSpan.FromSeconds(1), date => date.ToString("hh:mm:ss"))
                };
                chart.Series = Chart_series;
                chart.XAxes = xAxes;
                PageStackLayout.Children.Add(chart);
            }
            BindingContext = this;
        }

        private void ChartValue_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public Page1(ObservableCollection<TrendPoint> trendPoints)
        {
            InitializeComponent();
            alarmPoints = new ObservableCollection<AlarmPoint>();
            //trendviewsettingList = trendViewSettings;
            //foreach (var trendviewSetting in trendviewsettingList)
            //{
            //    var chart = new CartesianChart();
            //    _values = new ObservableCollection<DateTimePoint>();

            //    PageStackLayout.Children.Add(chart);

            //}
            SetTrendPoint(trendPoints);
            BindingContext = this;
        }
        public void AddNewTrendPoint(TrendPoint trendPoint)
        {
            List<ObservableCollection<DateTimePoint>> chartValueList = TagloggingIdLinesMap.Where(t=>t.Item1 == trendPoint.TagLoggingId).Select(t=>t.Item2).ToList();
            foreach (var charvalue in chartValueList)
            {
                charvalue.Add(new DateTimePoint(trendPoint.TimeStamp, trendPoint.Value));
            }

        }

        public void SetTrendPoint(ObservableCollection<TrendPoint> ptrendPoints)
        {
            //trendPoints = ptrendPoints;
            //trendPoints.CollectionChanged += TrendPoints_CollectionChanged;
            //_values = new ObservableCollection<DateTimePoint>();
            //foreach (TrendPoint trendPoint in trendPoints)
            //{
            //    _values.Add(new DateTimePoint(trendPoint.TimeStamp, trendPoint.Value));
            //}

            //Series = new ObservableCollection<ISeries>
            //  {
            //    new LineSeries<DateTimePoint>
            //    {
            //        Values = _values


            //    }
            // };
            //TrendChart.XAxes = XAxes;
            //TrendChart.Series = Series;
        }

        private void TrendPoints_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            { // Truy cập các phần tử mới được thêm vào
                foreach (var newItem in e.NewItems)
                {
                    var newPoint = newItem as TrendPoint;
                    if (newPoint != null)
                    {
                        AddTrendPoint(newPoint);
                    }
                }
            }
        }

        public Page1()
        {

        }

        private void lvAlarm_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        private void AddTrendPoint(TrendPoint trendPoint)
        {

            _values.Add(new DateTimePoint(trendPoint.TimeStamp, trendPoint.Value));
        }
        //public void AddAlarm() { }

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

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            _values.Add(new DateTimePoint(new DateTime(2021, 3, 1), 10.5));
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

    public class ChartViewModel
    {
        public ISeries[] Series { get; set; }
            = new ISeries[]
            {
                new LineSeries<double>
                {
                    Values = new double[] { 2, 1, 3, 5, 3, 4, 6 },
                    Fill = null
                }
            };
    }
}