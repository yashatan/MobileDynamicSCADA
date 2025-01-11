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
    public partial class SCADAViewPage : ContentPage
    {

        List<ControlData> controlDatas;
        Dictionary<ControlData, View> controlDataDictionary;
        private bool ControlIsLoaded;
        public new int Id { get; set; }
        public string Name { get; set; }
        public int PageType { get; set; }
        public SCADAViewPage()
        {
            InitializeComponent();
            ControlIsLoaded = false;
            Appearing += SCADAViewPageAppearing;
        }

        #region LoadPage
        public void SetControlDatas(List<ControlData> controlDatas)
        {
            this.controlDatas = controlDatas;
            AppSCADAController.Instance.TagUpdated += UpdateTagsSignalR;
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
                //set tagconnection update when lost focus
                if (control.GetType() == typeof(Entry))
                {
                    var entrycontrol = (control as Entry);
                    entrycontrol.Unfocused += SCADAViewPageLostFocus;
                }
                //register event
                if (controlData.ItemEvents.Count > 0)
                {
                    if (control.GetType() == typeof(Button))
                    {
                        var buttoncontrol = (control as Button);
                        buttoncontrol.Pressed += SCADAViewPagePressed;
                        buttoncontrol.Released += SCADAViewPageReleased;
                    }
                    else
                    {

                        var tapGestureRecognizer = new TapGestureRecognizer();
                        tapGestureRecognizer.Tapped += SCADAViewPagePressed;
                        control.GestureRecognizers.Add(tapGestureRecognizer);
                    }
                }
            }
            ForceScrollViewToRefresh();
        }



        private async void SCADAViewPageAppearing(object sender, EventArgs e)
        {
            if ((!ControlIsLoaded))
            {
                AddControlFromControlDatas();
                ControlIsLoaded = true;
                await AppSCADAController.Instance.RequestCurrentTagValue();
            }
        }
        #endregion

        #region Item Event
        private async void SCADAViewPageReleased(object sender, EventArgs e)
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
        private async void SCADAViewPageLostFocus(object sender, FocusEventArgs e)
        {
            ControlData controldata = controlDataDictionary.FirstOrDefault(p => p.Value.GetHashCode() == (sender as View).GetHashCode()).Key;
            var TagValue = (sender as Entry).Text;
            long datatowritelong;
            double datatowritedouble;
            if (controldata == null)
            {
                return;
            }
            if (controldata.TagConnection == null)
            {
                return;
            }
            if (controldata.TagConnection.Value != TagValue)
            {
                if (long.TryParse(TagValue, out datatowritelong))
                {
                    await AppSCADAController.Instance.WriteTagSignalR(controldata.TagConnection.Id, datatowritelong);
                }
                else if (double.TryParse(TagValue, out datatowritedouble))
                {
                    await AppSCADAController.Instance.WriteTagSignalR(controldata.TagConnection.Id, datatowritedouble);
                }
            }


        }
        private async void SCADAViewPagePressed(object sender, EventArgs e)
        {
            ControlData controldata = controlDataDictionary.FirstOrDefault(p => p.Value.GetHashCode() == (sender as View).GetHashCode()).Key;
            foreach (var itemevent in controldata.ItemEvents)
            {
                if (itemevent.EventType == ItemEvent.ItemEventType.emPress || itemevent.EventType == ItemEvent.ItemEventType.emClick)
                {
                    if (itemevent.ActionType == ItemEvent.ItemActiontype.emSetbit || itemevent.ActionType == ItemEvent.ItemActiontype.emResetBit)
                    {
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
                    else if (itemevent.ActionType == ItemEvent.ItemActiontype.emOpenScreen)
                    {
                        if (itemevent.PageType == 0)
                        {
                            SCADAViewPage page = App.SCADAViewPageList.FirstOrDefault(p => p.Id == itemevent.PageID);
                            if (page != null)
                            {
                                App.CurrentPageId = page.Id;
                                //await Shell.Current.GoToAsync(page);
                                App.mainFlyOut.Detail = new NavigationPage(page);
                            }
                        }
                        else if (itemevent.PageType == 1)
                        {
                            TableViewPage page = App.TableViewPageList.FirstOrDefault(p => p.Id == itemevent.PageID);
                            if (page != null)
                            {
                                await Navigation.PushAsync(page);
                            }
                        }

                    }
                }
            }
        }
        #endregion

        #region AnimationSense
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
                        double value = 0;
                        value = Convert.ToDouble(tag.Value);
                        //if (tag.Type == TagInfo.TagType.eReal)
                        //{
                        //    var temp = Convert.ToDouble(tag.Value);
                        //    value = Convert.ToDouble(temp);
                        //}
                        //else if (tag.Type == TagInfo.TagType.eDouble)
                        //{
                        //    var temp = Convert.ToDouble(tag.Value);
                        //    value = Convert.ToDouble(temp);

                        //}
                        //else
                        //{
                        //    value = Convert.ToInt32(tag.Value);
                        //}

                        if (value <= animation.Tagvaluemax && value >= animation.Tagvaluemin)
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
                                    case AnimationSense.PropertyType.emHeight:
                                        UpdateItemSize(controlDataDictionary[controldata], animation.PropertyValueWhenTagInRange, false);
                                        break;
                                    case AnimationSense.PropertyType.emWidth:
                                        UpdateItemSize(controlDataDictionary[controldata], animation.PropertyValueWhenTagInRange, true);
                                        break;
                                    case AnimationSense.PropertyType.emIsEnable:
                                        UpdateItemEnable(controlDataDictionary[controldata], animation.PropertyBoolValueWhenTagInRange);
                                        break;
                                    case AnimationSense.PropertyType.emText:
                                        UpdateItemText(controlDataDictionary[controldata], animation.TextWhenTagInRange);
                                        break;
                                    default: throw new ArgumentException();
                                }
                            });

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
            else if (item.GetType() == (typeof(Image)))
            {
                if ((item as Image).Source is FontImageSource fontImageSource)
                {
                    fontImageSource.Color = Color.FromRgb(colorWhenTagInRange.R, colorWhenTagInRange.G, colorWhenTagInRange.B);
                }
            }
        }
        private void UpdateItemVisible(View item, bool propertyBoolValueWhenTagInRange)
        {
            if (item != null)
            {
                item.IsVisible = propertyBoolValueWhenTagInRange;
            }
        }
        private void UpdateItemSize(View item, int propertyValueWhenTagInRange, bool isWidth)
        {
            if (item != null)
            {
                if (isWidth)
                {
                    item.WidthRequest = propertyValueWhenTagInRange;
                }
                else
                {
                    item.HeightRequest = propertyValueWhenTagInRange;
                }
            }
        }
        private void UpdateItemEnable(View item, bool propertyBoolValueWhenTagInRange)
        {
            if (item != null)
            {
                item.IsEnabled = propertyBoolValueWhenTagInRange;
            }
        }

        private void UpdateItemText(View item, string textWhenTagInRange)
        {
            if (item != null)
            {
                if (item.GetType() == (typeof(Label)))
                {
                    (item as Label).Text = textWhenTagInRange;
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
                        controldata.TagConnection.Data = tag.Data;
                        (controlDataDictionary[controldata] as Entry).Text = tag.Value;
                    });
                }
            }

        }
        #endregion
    }
}
