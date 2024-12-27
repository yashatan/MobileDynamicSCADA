using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Text.Json;
using System.IO;
using AppSCADA.Utility;
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
        List<ControlData> controlDatas;
        List<TrendViewSetting> trendViewSettings;
        Dictionary<ControlData, View> controlDataDictionary;
        List<TrendPoint> trendPoints;
        TrendPage trendPage;
        private bool ControlIsLoaded;
        public new int Id { get; set; }
        public string Name { get; set; }
        public MainPage()
        {
            InitializeComponent();
            ControlIsLoaded = false;
            Appearing += MainPage_Appearing;
        }
        private void Instance_TagUpdated(object sender, EventArgs e)
        {
            throw new NotImplementedException();
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
                        buttoncontrol.Released += MainPage_Released;
                    }
                }
            }
            ForceScrollViewToRefresh();
        }


        private async void MainPage_Released(object sender, EventArgs e)
        {
            ControlData controldata = controlDataDictionary.FirstOrDefault(p => p.Value.GetHashCode() == (sender as View).GetHashCode()).Key;
            foreach (var itemevent in controldata.ItemEvents)
            {
                if (itemevent.EventType == ItemEvent.ItemEventType.emRelease)
                {
                    if (itemevent.ActionType == ItemEvent.ItemActiontype.emSetbit || itemevent.ActionType == ItemEvent.ItemActiontype.emResetBit)
                    {
                        await AppSCADAController.Instance.WriteTagSignalR(itemevent.Tag.Id, (itemevent.ActionType == ItemEvent.ItemActiontype.emSetbit));
                    }
                    else if (itemevent.ActionType == ItemEvent.ItemActiontype.emSetValue)
                    {
                        await AppSCADAController.Instance.WriteTagSignalR(itemevent.Tag.Id, (itemevent.Value));
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
                        await AppSCADAController.Instance.WriteTagSignalR(itemevent.Tag.Id, (itemevent.ActionType == ItemEvent.ItemActiontype.emSetbit));
                    }
                    else if (itemevent.ActionType == ItemEvent.ItemActiontype.emSetValue)
                    {
                        if (itemevent.Tag.Type == TagInfo.TagType.eByte)
                        {
                            await AppSCADAController.Instance.WriteTagSignalR(itemevent.Tag.Id, (itemevent.Value));
                        }
                        else if (itemevent.Tag.Type == TagInfo.TagType.eShort)
                        {
                            await AppSCADAController.Instance.WriteTagSignalR(itemevent.Tag.Id, (itemevent.Value));

                        }

                    }
                }
            }
        }

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


        private void ReceiveCurrentTrendPointsSignalR(List<TrendPoint> trendPoints)
        {
            trendPage.SetCurrentTrendPoints(trendPoints);
        }

        private void ReceiveTrendPointSignalR(TrendPoint trendPoint)
        {
            trendPoints.Add(trendPoint);
            trendPage.AddNewTrendPoint(trendPoint);
        }


        private void UpdateTagsSignalR(TagInfo tag)
        {

            var controldatas = controlDatas.Where(p => p.animationSenses != null && p.animationSenses.Any(a => a.Tag != null && a.Tag.Id == tag.Id)).ToList();
            if (controldatas.Any())
            {
                foreach (var controldata in controldatas)
                {
                    UpdateAnimation(tag, controldata);
                }
            }
            controldatas = controlDatas.Where(p => ((p.TagConnection != null) && (p.TagConnection.Id == tag.Id))).ToList();
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

        private async void Trend_button_Clicked(object sender, EventArgs e)
        {
            ////await Navigation.PushAsync(new Page1());
            //trendPage = new TrendPage();
            ////trendPage.AlarmACK += AlarmPage_AlarmACK;
            //trendPage.RequestCurrentTrendPoints(_hubProxy);
            //await Navigation.PushAsync(trendPage);

        }

        private void AlarmPage_AlarmACK(object sender, AlarmPointACKEventArgs e)
        {
            //AckAlarmPointSignalR(e.AlarmPoint.Id);
        }

        private async void Alarm_button_Clicked(object sender, EventArgs e)
        {
            //alarmPage = new AlarmPage(alarmPoints);
            //alarmPage.AlarmACK += AlarmPage_AlarmACK;
            //await Navigation.PushAsync(alarmPage);

        }

        #region LoadPage
        public void SetControlDatas(List<ControlData> controlDatas)
        {
            this.controlDatas = controlDatas;
            AppSCADAController.Instance.TagUpdated += UpdateTagsSignalR;
        }
        #endregion
    }
}
