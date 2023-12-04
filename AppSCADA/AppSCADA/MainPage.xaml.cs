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
using System.Timers;
using S7.Net;
using Xamarin.Forms.Shapes;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Essentials;
using System.Text.Json.Serialization;
using Android.Views.Accessibility;
using static Android.Content.ClipData;

namespace AppSCADA
{
    public partial class MainPage : ContentPage
    {
        //S7PlcService _plc;
        List<ControlData> controlDatas;
        Dictionary<int, ControlData> controlDataDictionary;
        Plc thePLC;
        string IP = "192.168.1.201";
        System.Timers.Timer UpdateTimer;
        private volatile object _locker = new object();
        public MainPage()
        {
            InitializeComponent();
            this.Appearing += MainPage_AppearingAsync;//Load file and start PLC after 

        }

        private async void MainPage_AppearingAsync(object sender, EventArgs e)
        {
            var fileResult = await FilePicker.PickAsync();
            if (fileResult != null)
            {
                var filestream = await fileResult.OpenReadAsync();
                controlDatas = DeserializeControlData(filestream);
            }


            AddControlFromControlDatas();
            try
            {
                thePLC = new Plc(CpuType.S71500, IP, 0, 1);
                thePLC.Open();
                UpdateTimer = new System.Timers.Timer(500);
                UpdateTimer.Elapsed += UpdateTags;
                UpdateTimer.Start();
            }
            catch { }
        }

        private void AddControlFromControlDatas()
        {
            controlDataDictionary = new Dictionary<int, ControlData>();

            foreach (var controlData in controlDatas)
            {
                var control = ControlDecoder.ConvertToControl(controlData);
                UpdateMainScreenSize(controlData);
                MainScreen.Children.Add(control, new Point(controlData.X, controlData.Y));
                controlDataDictionary.Add(control.GetHashCode(), controlData);

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

        }


        private void Item_Released(object sender, EventArgs e)
        {
            ControlData controldata = controlDataDictionary[(sender as View).GetHashCode()];
            foreach (var itemevent in controldata.ItemEvents)
            {
                if (itemevent.EventType == ItemEvent.ItemEventType.emRelease)
                {
                    WritePLCTag(itemevent.TagName, (itemevent.ActionType == ItemEvent.ItemActiontype.emSetbit));
                }
            }
        }

        private void MainPage_Pressed(object sender, EventArgs e)
        {
            ControlData controldata = controlDataDictionary[(sender as View).GetHashCode()];
            foreach (var itemevent in controldata.ItemEvents)
            {
                if (itemevent.EventType == ItemEvent.ItemEventType.emPress)
                {
                    WritePLCTag(itemevent.TagName, (itemevent.ActionType == ItemEvent.ItemActiontype.emSetbit));
                }
            }
        }

        private void UpdateTags(object sender, ElapsedEventArgs e)
        {
            try
            {
                UpdateTimer.Stop();
                // ScanTime = DateTime.Now - _lastScanTime;
                lock (_locker)
                {
                    var children = MainScreen.Children;
                    foreach (View item in children)
                    {

                        ControlData controldata = controlDataDictionary[item.GetHashCode()];
                        foreach (AnimationSense animation in controldata.animationSenses)
                        {
                            int tagvalue = ReadPLCTag(animation.Tagname);
                            if (tagvalue <= animation.Tagvaluemin && tagvalue >= animation.Tagvaluemax)
                            {
                                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                                {
                                    //item.IsVisible = true;
                                    //item.GetType().GetProperty(animation.PropertyNeedChange).SetValue(item, Convert.ToBoolean(animation.PropertyValueWhenTagMin), null);
                                    switch (animation.PropertyNeedChange)
                                    {
                                        case AnimationSense.PropertyType.emIsVisible:
                                            UpdateItemVisible(item, animation.PropertyBoolValueWhenTagInRange);
                                            break;
                                        case AnimationSense.PropertyType.emBackgroundcColor:
                                            UpdateItemColor(item, animation.ColorWhenTagInRange);
                                            break;
                                        default: throw new ArgumentException();
                                    }
                                });


                            }
                        }
                        if (controldata.TagConnection != null)
                        {
                            Device.BeginInvokeOnMainThread(() =>
                            {
                                //item.IsVisible = false;
                                (item as Entry).Text = ReadPLCTag(controldata.TagConnection).ToString();
                            });



                        }
                    }
                }
            }
            finally
            {
                UpdateTimer.Start();
            }

        }

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
    }
}
