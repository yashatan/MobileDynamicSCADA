using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Text.Json;
using System.IO;
using AppSCADA.Utility;
using S7.Net;
using Xamarin.Forms.Shapes;
using Microsoft.AspNet.SignalR.Client;
using System.Collections.ObjectModel;
using HarfBuzzSharp;
using static System.Net.WebRequestMethods;
using Xamarin.Essentials;

namespace AppSCADA
{
    public partial class MainPage : ContentPage
    {
        //S7PlcService _plc;
        HubConnection _signalRConnection;
        //Proxy object for a hub hosted on the SignalR server
        IHubProxy _hubProxy;
        List<ControlData> controlDatas;
        List<TrendViewSetting> trendViewSettings;
        ObservableCollection<AlarmPoint> alarmPoints;
        ObservableCollection<TrendPoint> trendPoints;
        Dictionary<ControlData, View> controlDataDictionary;
        public string url;
        TrendPage trendPage;
        AlarmPage alarmPage;
        private bool ControlIsLoaded;
        public MainPage()
        {
            InitializeComponent();
            //this.Appearing += MainPage_AppearingAsync;//Load file and start PLC after 
            alarmPoints = new ObservableCollection<AlarmPoint>();
            trendPoints = new ObservableCollection<TrendPoint>();
            ControlIsLoaded = false;
            Appearing += MainPage_Appearing;
        }

        private void MainPage_Appearing(object sender, EventArgs e)
        {
            if ((!ControlIsLoaded))
            {
                AddControlFromControlDatas();
                ControlIsLoaded = true;
            }
        }

        private void ForceScrollViewToRefresh()
        { 
            var currentContent = scrollViewMain.Content;
            scrollViewMain.Content = null;
            scrollViewMain.Content = currentContent;
        }
        private void AddControlFromControlDatas()
        {
            controlDataDictionary = new Dictionary<ControlData, View>();
            foreach (var controlData in controlDatas)
            {
                var control = ControlDecoder.ConvertToControl(controlData);

                Device.BeginInvokeOnMainThread(() =>
                {
                    try
                    {
                        UpdateMainScreenSize(controlData);
                        MainScreen.Children.Add(control, new Point(controlData.X, controlData.Y));
                    }
                    catch
                    {
                        // tcs.SetException(e);
                    }
                });

                controlDataDictionary.Add(controlData, control);
                // SCADAItems.Add(control);
                if (controlData.ItemEvents.Count > 0)
                {
                    if (control.GetType() == typeof(Button))
                    {
                        var buttoncontrol = (control as Button);
                        buttoncontrol.Pressed += MainPage_Pressed;
                        buttoncontrol.Released += Item_Released;
                    }
                }
            }
            ForceScrollViewToRefresh();
            //Device.BeginInvokeOnMainThread(() => { LoadingCircle.IsRunning = false; });
        }


        private async void Item_Released(object sender, EventArgs e)
        {
            //ControlData controldata = controlDataDictionary[(sender as View).GetHashCode()];
            ControlData controldata = controlDataDictionary.FirstOrDefault(p => p.Value.GetHashCode() == (sender as View).GetHashCode()).Key;
            foreach (var itemevent in controldata.ItemEvents)
            {
                if (itemevent.EventType == ItemEvent.ItemEventType.emRelease)
                {
                    //WritePLCTag(itemevent.TagName, (itemevent.ActionType == ItemEvent.ItemActiontype.emSetbit));
                    if (itemevent.ActionType == ItemEvent.ItemActiontype.emSetbit || itemevent.ActionType == ItemEvent.ItemActiontype.emResetBit)
                    {
                        await WriteTagSignalR(itemevent.Tag.Id, (itemevent.ActionType == ItemEvent.ItemActiontype.emSetbit));
                    }
                    else if (itemevent.ActionType == ItemEvent.ItemActiontype.emSetValue)
                    {
                        await WriteTagSignalR(itemevent.Tag.Id, (itemevent.Value));
                    }

                }
            }
        }

        private async void MainPage_Pressed(object sender, EventArgs e)
        {
            ControlData controldata = controlDataDictionary.FirstOrDefault(p => p.Value.GetHashCode() == (sender as View).GetHashCode()).Key;
            foreach (var itemevent in controldata.ItemEvents)
            {
                if (itemevent.EventType == ItemEvent.ItemEventType.emPress)
                {
                    if (itemevent.ActionType == ItemEvent.ItemActiontype.emSetbit || itemevent.ActionType == ItemEvent.ItemActiontype.emResetBit)
                    {
                        //WritePLCTag(itemevent.TagName, (itemevent.ActionType == ItemEvent.ItemActiontype.emSetbit));
                        await WriteTagSignalR(itemevent.Tag.Id, (itemevent.ActionType == ItemEvent.ItemActiontype.emSetbit));
                    }
                    else if (itemevent.ActionType == ItemEvent.ItemActiontype.emSetValue)
                    {
                        if (itemevent.Tag.Type == TagInfo.TagType.eByte)
                        {
                            await WriteTagSignalR(itemevent.Tag.Id, (itemevent.Value));
                        }
                        else if (itemevent.Tag.Type == TagInfo.TagType.eShort)
                        {
                            await WriteTagSignalR(itemevent.Tag.Id, (itemevent.Value));

                        }

                    }
                }
            }
        }

        //private void UpdateTags(object sender, ElapsedEventArgs e)
        //{
        //    try
        //    {
        //        UpdateTimer.Stop();
        //        // ScanTime = DateTime.Now - _lastScanTime;
        //        lock (_locker)
        //        {
        //            var children = MainScreen.Children;
        //            foreach (View item in children)
        //            {

        //                ControlData controldata = controlDataDictionary[item.GetHashCode()];
        //                foreach (AnimationSense animation in controldata.animationSenses)
        //                {
        //                    int tagvalue = ReadPLCTag(animation.Tag.MemoryAddress);
        //                    if (tagvalue <= animation.Tagvaluemin && tagvalue >= animation.Tagvaluemax)
        //                    {
        //                        Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
        //                        {
        //                            //item.IsVisible = true;
        //                            //item.GetType().GetProperty(animation.PropertyNeedChange).SetValue(item, Convert.ToBoolean(animation.PropertyValueWhenTagMin), null);
        //                            switch (animation.PropertyNeedChange)
        //                            {
        //                                case AnimationSense.PropertyType.emIsVisible:
        //                                    UpdateItemVisible(item, animation.PropertyBoolValueWhenTagInRange);
        //                                    break;
        //                                case AnimationSense.PropertyType.emBackgroundColor:
        //                                    UpdateItemColor(item, animation.ColorWhenTagInRange);
        //                                    break;
        //                                default: throw new ArgumentException();
        //                            }
        //                        });


        //                    }
        //                }
        //                if (controldata.TagConnection != null)
        //                {
        //                    Device.BeginInvokeOnMainThread(() =>
        //                    {
        //                        //item.IsVisible = false;
        //                        //  (item as Entry).Text = ReadPLCTag(controldata.TagConnection).ToString();
        //                    });



        //                }
        //            }
        //        }
        //    }
        //    finally
        //    {
        //        UpdateTimer.Start();
        //    }

        //}

        private void UpdateItemColor(View item, ColorRGB colorWhenTagInRange)
        {
            if (item.GetType().IsSubclassOf(typeof(Shape)))
            {
                (item as Shape).Fill = new SolidColorBrush(Xamarin.Forms.Color.FromRgb(colorWhenTagInRange.R, colorWhenTagInRange.G, colorWhenTagInRange.B));
            }
            else if (item.GetType() == (typeof(Button)))
            {
                (item as Button).BackgroundColor = Xamarin.Forms.Color.FromRgb(colorWhenTagInRange.R, colorWhenTagInRange.G, colorWhenTagInRange.B);
            }
            else if (item.GetType() == (typeof(Entry)))
            {
                (item as Entry).BackgroundColor = Xamarin.Forms.Color.FromRgb(colorWhenTagInRange.R, colorWhenTagInRange.G, colorWhenTagInRange.B);
            }
            else if (item.GetType() == (typeof(Label)))
            {
                (item as Label).BackgroundColor = Xamarin.Forms.Color.FromRgb(colorWhenTagInRange.R, colorWhenTagInRange.G, colorWhenTagInRange.B);
            }
        }

        private void UpdateItemVisible(View item, bool propertyBoolValueWhenTagInRange)
        {
            if (item != null)
            {
                item.IsVisible = propertyBoolValueWhenTagInRange;
            }
        }

        //int ReadPLCTag(string tag)
        //{
        //    object ob1 = thePLC.Read(tag);
        //    var result = Convert.ToInt16(ob1);
        //    return result;
        //}

        //void WritePLCTag(string tag, object value)
        //{
        //    lock (_locker)
        //    {
        //        thePLC.Write(tag, value);
        //    }

        //}
        public static List<ControlData> DeserializeControlData(Stream filePath)
        {
            List<ControlData> listControls;
            using (var reader = new StreamReader(filePath))
            {
                var jsonString = reader.ReadToEnd();

                listControls = JsonSerializer.Deserialize<List<ControlData>>(jsonString);
            }
            //string jsonString = File.ReadAllText(filePath);

            return listControls;
        }
        double needwid;
        double needhei;
        private void UpdateMainScreenSize(ControlData controldata)
        {
            if (MainScreen.Height < controldata.Y + controldata.Height)
            {
                var neededHeight = controldata.Y + controldata.Height;
                needhei = neededHeight;
                MainScreen.HeightRequest = neededHeight;
                MainScreen.ResolveLayoutChanges();
            }
            if (MainScreen.Width < controldata.X + controldata.Width)
            {
                var neededWidth = controldata.X + controldata.Width;
                needwid = neededWidth;
                MainScreen.WidthRequest = neededWidth;
                MainScreen.ResolveLayoutChanges();
            }
        }
        public async Task connectAsync()
        {
            //Create a connection for the SignalR server
            var url_temp = url;
            var _signalRConnection = new HubConnection(url);
            _signalRConnection.StateChanged += HubConnection_StateChanged;

            _hubProxy = _signalRConnection.CreateHubProxy("SCADAHub");
            _hubProxy.On<int, int>("UpdateTags", (tagid, value) => UpdateTagsSignalR(tagid, value));
            _hubProxy.On<SCADAAppConfiguration>("DownloadSCADAConfig", (config) => GetSCADAConfig(config));
            _hubProxy.On<AlarmPoint>("UpdateAlarmPoint", (alarmPoint) => ReceiveAlarmPointSignalR(alarmPoint));
            _hubProxy.On<int>("ACKAlarmPoint", (alarmPointId) => ReceiveACKAlarmPointSignalR(alarmPointId));
            _hubProxy.On<TrendPoint>("WriteTrendPoint", (trendPoint) => ReceiveTrendPointSignalR(trendPoint));
            _hubProxy.On<List<TrendPoint>>("WriteCurrentTrendPoints", (trendPoints) => ReceiveCurrentTrendPointsSignalR(trendPoints));

            //btnConnect.Enabled = false;

            try
            {
                //Connect to the server
                await _signalRConnection.Start();
                await _hubProxy.Invoke("SetUserName", DeviceInfo.Name);
                //Connect_button.Text = "Disconnect";
            }
            catch (Exception ex)
            {
                // writeToLog($"Error:{ex.Message}");
                // btnConnect.Enabled = true;
            }
        }

        private void ReceiveCurrentTrendPointsSignalR(List<TrendPoint> trendPoints)
        {
            trendPage.SetCurrentTrendPoints(trendPoints);
        }

        private void ReceiveTrendPointSignalR(TrendPoint trendPoint)
        {
            trendPoints.Add(trendPoint);
            trendPage.AddNewTrendPoint(trendPoint);
        }

        private void ReceiveACKAlarmPointSignalR(int alarmPointId)
        {
            alarmPoints.Remove(alarmPoints.FirstOrDefault(ap => ap.Id == alarmPointId));
        }

        private void ReceiveAlarmPointSignalR(AlarmPoint alarmPoint)
        {
            alarmPoints.Add(alarmPoint);
        }

        private async void AckAlarmPointSignalR(int alarmId)
        {
            await _hubProxy.Invoke("AckAlarmPoint", alarmId);
            alarmPoints.Remove(alarmPoints.FirstOrDefault(ap => ap.Id == alarmId));
        }



        private void GetSCADAConfig(SCADAAppConfiguration config)
        {
            AppSCADAProperties.SCADAAppConfiguration = config;
            AppSCADAProperties.TrendLimitPoints = 80;
            if (AppSCADAProperties.SCADAAppConfiguration != null)
            {
                if (AppSCADAProperties.SCADAAppConfiguration.SCADAPages != null)
                {
                    controlDatas = AppSCADAProperties.SCADAAppConfiguration.SCADAPages.Where(m => m.Name == "MainPage").First().ControlDatas;
                }
                if (config.CurrentAlarmPoints != null)
                {
                    foreach (var alarmPoint in AppSCADAProperties.SCADAAppConfiguration.CurrentAlarmPoints)
                    {
                        alarmPoints.Add(alarmPoint);
                    }
                }
                if (AppSCADAProperties.SCADAAppConfiguration.TrendViewSettings != null)
                {
                    trendViewSettings = AppSCADAProperties.SCADAAppConfiguration.TrendViewSettings;
                }


            }

        }

        private void UpdateTagsSignalR(int tagid, long value)
        {
            var tag = AppSCADAProperties.SCADAAppConfiguration.TagInfos.FirstOrDefault(m => m.Id == tagid);
            tag.Data = value;
            var controldatas = controlDatas.Where(p => ((p.animationSenses.Where(a => a.Tag.Id == tagid).Any()))).ToList();
            if (controldatas.Any())
            {
                foreach (var controldata in controldatas)
                {
                    UpdateAnimation(tag, controldata);
                }
            }

            controldatas = controlDatas.Where(p => ((p.TagConnection != null) && (p.TagConnection.Id == tagid))).ToList();
            if (controldatas.Any())
            {
                foreach (var controldata in controldatas)
                {
                    UpdateTagConnection(tag, controldata);
                }
            }

        }

        private void UpdateAnimation(TagInfo tag, ControlData controldata)
        {
            if (ControlIsLoaded)
            {
                var animations = controldata.animationSenses.Where(p => p.Tag.Id == tag.Id).ToList();
                // animation.Tag.Value = value;
                if (animations.Any())
                {
                    foreach (AnimationSense animation in animations)
                    {
                        int value = 0;
                        if (tag.Type == TagInfo.TagType.eReal)
                        {
                            var temp = Convert.ToSingle(tag.Value);
                            value = Convert.ToInt32(temp);
                        }
                        else if (tag.Type == TagInfo.TagType.eDouble)
                        {
                            var temp = Convert.ToDouble(tag.Value);
                            value = Convert.ToInt32(temp);

                        }
                        else
                        {
                            value = Convert.ToInt32(tag.Value);
                        }

                        if (value <= animation.Tagvaluemin && value >= animation.Tagvaluemax)
                        {
                            Device.BeginInvokeOnMainThread(() =>
                            {
                                switch (animation.PropertyNeedChange)
                                {
                                    case AnimationSense.PropertyType.emIsVisible:
                                        UpdateItemVisible(controlDataDictionary[controldata], animation.PropertyBoolValueWhenTagInRange);
                                        break;
                                    case AnimationSense.PropertyType.emBackgroundColor:
                                        UpdateItemColor(controlDataDictionary[controldata], animation.ColorWhenTagInRange);
                                        break;
                                    default: throw new ArgumentException();
                                }
                            });

                        }
                    }
                }
            }

        }

        private void UpdateTagConnection(TagInfo tag, ControlData controldata)
        {
            if (ControlIsLoaded)
            {
                if (controldata.TagConnection != null)
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        //item.IsVisible = false;
                        (controlDataDictionary[controldata] as Entry).Text = tag.Value;
                    });
                }
            }

        }

        private async Task WriteTagSignalR(int tagid, object value)
        {
            await _hubProxy.Invoke("WriteTag", tagid, value);
        }
        private void HubConnection_StateChanged(StateChange obj)
        {
            if (obj.NewState == Microsoft.AspNet.SignalR.Client.ConnectionState.Connected)
                Console.WriteLine("Connected");
            else if (obj.NewState == Microsoft.AspNet.SignalR.Client.ConnectionState.Disconnected)
                Console.WriteLine("Disconnected");
        }

        private async void Connect_button_Clicked(object sender, EventArgs e)
        {
            //LoadingCircle.IsRunning = true;
            await connectAsync();
        }

        private async void Trend_button_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new Page1());
            trendPage = new TrendPage();
            //trendPage.AlarmACK += AlarmPage_AlarmACK;
            trendPage.RequestCurrentTrendPoints(_hubProxy);
            await Navigation.PushAsync(trendPage);

        }

        private void AlarmPage_AlarmACK(object sender, AlarmPointACKEventArgs e)
        {
            AckAlarmPointSignalR(e.AlarmPoint.Id);
        }

        private async void Alarm_button_Clicked(object sender, EventArgs e)
        {
            //alarmPage = new AlarmPage(alarmPoints);
            //alarmPage.AlarmACK += AlarmPage_AlarmACK;
            //await Navigation.PushAsync(alarmPage);

        }
        //double currentScale = 1; double startScale = 1;
        //private void PinchGestureRecognizer_PinchUpdated(object sender, PinchGestureUpdatedEventArgs e)
        //{
        //    if (e.Status == GestureStatus.Started)
        //    {
        //        // Bắt đầu pinch, lưu trữ scale ban đầu
        //        startScale = MainScreen.Scale;
        //        MainScreen.AnchorX = 0;
        //        MainScreen.AnchorY = 0;
        //    }
        //    else if (e.Status == GestureStatus.Running)
        //    {
        //        // Tính toán scale mới
        //        currentScale = startScale * e.Scale;
        //        //currentScale = Math.Max(1, currentScale); // Đảm bảo scale không nhỏ hơn 1
        //        MainScreen.Scale = currentScale;
        //    }
        //    else if (e.Status == GestureStatus.Completed)
        //    {
        //        // Lưu trữ scale cuối cùng
        //        startScale = currentScale;
        //    }
        //}
    }
}
