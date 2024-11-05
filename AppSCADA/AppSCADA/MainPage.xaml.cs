using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using AppSCADA.ViewModel;
using System.Text.Json;
using System.Reflection;
using System.IO;
using AppSCADA.Utility;
using System.Threading;
using System.Linq;
using System.Timers;
using S7.Net;
using Xamarin.Forms.Shapes;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Essentials;
using System.Text.Json.Serialization;
using Android.Views.Accessibility;
using static Android.Content.ClipData;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNet.SignalR.Client.Hubs;
using Android.Nfc;
using static Android.Renderscripts.Sampler;

namespace AppSCADA
{
    public partial class MainPage : ContentPage
    {
        //S7PlcService _plc;
        HubConnection _signalRConnection;
        //Proxy object for a hub hosted on the SignalR server
        IHubProxy _hubProxy;
        List<ControlData> controlDatas;
        List<AlarmPoint> alarmPoints;
        Dictionary<ControlData, View> controlDataDictionary;
        Plc thePLC;
        string IP = "192.168.0.201";
        System.Timers.Timer UpdateTimer;
        private volatile object _locker = new object();
        public MainPage()
        {
            InitializeComponent();
            this.Appearing += MainPage_AppearingAsync;//Load file and start PLC after 
            alarmPoints = new List<AlarmPoint>();
        }

        private async void MainPage_AppearingAsync(object sender, EventArgs e)
        {
            //var fileResult = await FilePicker.PickAsync();
            //if (fileResult != null)
            //{
            //    var filestream = await fileResult.OpenReadAsync();
            //    controlDatas = DeserializeControlData(filestream);
            //}

            //  AddControlFromControlDatas();
        }

        private void AddControlFromControlDatas()
        {
            controlDataDictionary = new Dictionary<ControlData, View>();
            foreach (var controlData in controlDatas)
            {
                var control = ControlDecoder.ConvertToControl(controlData);
                UpdateMainScreenSize(controlData);
                Device.BeginInvokeOnMainThread(() =>
                {
                    try
                    {
                        MainScreen.Children.Add(control, new Point(controlData.X, controlData.Y));
                        //action();
                        //tcs.SetResult(null);
                    }
                    catch (Exception e)
                    {
                        //    tcs.SetException(e);
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
            Device.BeginInvokeOnMainThread(() => { LoadingCircle.IsRunning = false; });
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
                    await WriteTagSignalR(itemevent.Tag.Id, (itemevent.ActionType == ItemEvent.ItemActiontype.emSetbit));
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
                    //WritePLCTag(itemevent.TagName, (itemevent.ActionType == ItemEvent.ItemActiontype.emSetbit));
                    await WriteTagSignalR(itemevent.Tag.Id, (itemevent.ActionType == ItemEvent.ItemActiontype.emSetbit));
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
                (item as Shape).Fill = new SolidColorBrush(Color.FromRgb(colorWhenTagInRange.R, colorWhenTagInRange.G, colorWhenTagInRange.B));
            }
            else if (item.GetType() == (typeof(Button)))
            {
                (item as Button).BackgroundColor = Color.FromRgb(colorWhenTagInRange.R, colorWhenTagInRange.G, colorWhenTagInRange.B);
            }
            else if (item.GetType() == (typeof(Entry)))
            {
                (item as Entry).BackgroundColor = Color.FromRgb(colorWhenTagInRange.R, colorWhenTagInRange.G, colorWhenTagInRange.B);
            }
            else if (item.GetType() == (typeof(Label)))
            {
                (item as Label).BackgroundColor = Color.FromRgb(colorWhenTagInRange.R, colorWhenTagInRange.G, colorWhenTagInRange.B);
            }
        }

        private void UpdateItemVisible(View item, bool propertyBoolValueWhenTagInRange)
        {
            if (item != null)
            {
                item.IsVisible = propertyBoolValueWhenTagInRange;
            }
        }

        int ReadPLCTag(string tag)
        {
            object ob1 = thePLC.Read(tag);
            var result = Convert.ToInt16(ob1);
            return result;
        }

        void WritePLCTag(string tag, object value)
        {
            lock (_locker)
            {
                thePLC.Write(tag, value);
            }

        }
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

        private void UpdateMainScreenSize(ControlData controldata)
        {

            if (MainScreen.Height < controldata.Y + controldata.Height)
            {
                var neededHeight = controldata.Y + controldata.Height;
                MainScreen.HeightRequest = neededHeight;
                MainScreen.ResolveLayoutChanges();
            }
            if (MainScreen.Width < controldata.X + controldata.Width)
            {
                var neededWidth = controldata.X + controldata.Width;
                MainScreen.WidthRequest = neededWidth;
                MainScreen.ResolveLayoutChanges();
            }

        }
        private async Task connectAsync()
        {
            //Create a connection for the SignalR server
            var url = IPAddress.Text;
            var _signalRConnection = new HubConnection(url);
            _signalRConnection.StateChanged += HubConnection_StateChanged;

            //Get a proxy object that will be used to interact with the specific hub on the server
            //Ther may be many hubs hosted on the server, so provide the type name for the hub
            _hubProxy = _signalRConnection.CreateHubProxy("SCADAHub");

            //Reigster to the "AddMessage" callback method of the hub
            //This method is invoked by the hub
            // await Console.Out.WriteLineAsync();
            _hubProxy.On<int, int>("UpdateTags", (tagid, value) => UpdateTagsSignalR(tagid, value));
            _hubProxy.On<SCADAAppConfiguration>("DownloadSCADAConfig", (config) => GetSCADAConfig(config));
            _hubProxy.On<AlarmPoint>("UpdateAlarmPoint", (alarmPoint) => ReceiveAlarmPointSignalR(alarmPoint));
            //_hubProxy.On<int, int>("GetData", (tagid, value) => UpdateTagsSignalR(tagid, value));
            //_hubProxy.On<TagInfo, ConnectDevice>("SendTagInfo", (tagInfo, device) => TestFunction(tagInfo, device));

            //btnConnect.Enabled = false;

            try
            {
                //Connect to the server
                await _signalRConnection.Start();
                await _hubProxy.Invoke("SetUserName", "test");
            }
            catch (Exception ex)
            {
                // writeToLog($"Error:{ex.Message}");
                // btnConnect.Enabled = true;
            }
        }

        private void ReceiveAlarmPointSignalR(AlarmPoint alarmPoint)
        {
            alarmPoints.Add(alarmPoint);
        }

        private async void AckAlarmPointSignalR(int alarmId)
        {
            await _hubProxy.Invoke("AckAlarmPoint", alarmId);
        }

        private void GetSCADAConfig(SCADAAppConfiguration config)
        {
            controlDatas = config.ControlDatas;
            AddControlFromControlDatas();
        }

        private void UpdateTagsSignalR(int tagid, int value)
        {
            var controldatas = controlDatas.Where(p => ((p.animationSenses.Where(a => a.Tag.Id == tagid).Any()))).ToList();
            if (controldatas.Any())
            {
                foreach (var controldata in controldatas)
                {
                    UpdateAnimation(tagid, value, controldata);
                }
            }

            controldatas = controlDatas.Where(p => ((p.TagConnection != null) && (p.TagConnection.Id == tagid))).ToList();
            if (controldatas.Any())
            {
                foreach (var controldata in controldatas)
                {
                    UpdateTagConnection(tagid, value, controldata);
                }
            }

        }

        private void UpdateAnimation(int tagid, int value, ControlData controldata)
        {
            var animations = controldata.animationSenses.Where(p => p.Tag.Id == tagid).ToList();
            // animation.Tag.Value = value;
            if (animations.Any())
            {
                foreach (AnimationSense animation in animations)
                {
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

        private void UpdateTagConnection(int tagid, int value, ControlData controldata)
        {
            if (controldata.TagConnection != null)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    //item.IsVisible = false;
                    (controlDataDictionary[controldata] as Entry).Text = value.ToString();
                });
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
            await connectAsync();
        }
    }
}
