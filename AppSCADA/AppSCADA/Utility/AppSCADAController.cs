﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNet.SignalR.Client;
using System.Collections.ObjectModel;
using Microsoft.AspNet.SignalR.Client.Hubs;
using System.Net;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;
using Xamarin.Essentials;
using System.Threading;
using HarfBuzzSharp;

namespace AppSCADA.Utility
{
    public class AppSCADAController
    {
        ObservableCollection<AlarmPoint> alarmPoints;
        ObservableCollection<TrendPoint> trendPoints;

        #region Constructor
        private static AppSCADAController instance;
        public static AppSCADAController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AppSCADAController();
                }
                return instance;
            }
        }
        public string url;
        private AppSCADAController()
        {
            alarmPoints = new ObservableCollection<AlarmPoint>();
            trendPoints = new ObservableCollection<TrendPoint>();
        }
        #endregion


        #region SignalR
        HubConnection _signalRConnection;
        IHubProxy _hubProxy;
        public string serverURL { get; set; }
        public async Task<bool> connectAsync()
        {
            //Create a connection for the SignalR server
            var url = serverURL;
            _signalRConnection = new HubConnection(url);
            //_signalRConnection.DeadlockErrorTimeout = TimeSpan.FromSeconds(5);
            _signalRConnection.TransportConnectTimeout = TimeSpan.FromSeconds(5);
            _signalRConnection.StateChanged += HubConnection_StateChanged;

            _hubProxy = _signalRConnection.CreateHubProxy("SCADAHub");
            _hubProxy.On<int, int>("UpdateTags", (tagid, value) => UpdateTagsSignalR(tagid, value));
            _hubProxy.On<SCADAAppConfiguration>("DownloadSCADAConfig", (config) => GetSCADAConfig(config));
            _hubProxy.On<AlarmPoint>("UpdateAlarmPoint", (alarmPoint) => ReceiveAlarmPointSignalR(alarmPoint));
            _hubProxy.On<int>("ACKAlarmPoint", (alarmPointId) => ReceiveACKAlarmPointSignalR(alarmPointId));
            _hubProxy.On<TrendPoint>("WriteTrendPoint", (trendPoint) => ReceiveTrendPointSignalR(trendPoint));
            _hubProxy.On<List<TrendPoint>>("WriteCurrentTrendPoints", (trendPoints) => ReceiveCurrentTrendPointsSignalR(trendPoints));
            using (var cts = new CancellationTokenSource(TimeSpan.FromSeconds(10)))
            {
                try
                {
                    var connectTask = _signalRConnection.Start();

                    if (await Task.WhenAny(connectTask, Task.Delay(Timeout.Infinite, cts.Token)) == connectTask)
                    {
                        await connectTask;
                        await _hubProxy.Invoke("SetUserName", DeviceInfo.Name);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        private void HubConnection_StateChanged(StateChange obj)
        {
            if (obj.NewState == Microsoft.AspNet.SignalR.Client.ConnectionState.Connected)
                Console.WriteLine("Connected");
            else if (obj.NewState == Microsoft.AspNet.SignalR.Client.ConnectionState.Disconnected)
                Console.WriteLine("Disconnected");
        }
        private void UpdateTagsSignalR(int tagid, long value)
        {
            var tag = AppSCADAProperties.SCADAAppConfiguration.TagInfos.FirstOrDefault(m => m.Id == tagid);
            tag.Data = value;
            TagUpdated?.Invoke(tag);
        }

        private async void GetSCADAConfig(SCADAAppConfiguration config)
        {
            AppSCADAProperties.SCADAAppConfiguration = config;
            AppSCADAProperties.TrendLimitPoints = 80;
            if (AppSCADAProperties.SCADAAppConfiguration != null)
            {
                if (AppSCADAProperties.SCADAAppConfiguration.SCADAPages != null)
                {
                    foreach (var page in AppSCADAProperties.SCADAAppConfiguration.SCADAPages)
                    {
                        SCADAViewPage scadaViewPage = new SCADAViewPage();
                        scadaViewPage.SetControlDatas(page.ControlDatas);
                        scadaViewPage.Id = page.Id;
                        scadaViewPage.Name = page.Name;
                        App.SCADAViewPageList.Add(scadaViewPage);
                    }
                }
                if (AppSCADAProperties.SCADAAppConfiguration.CurrentAlarmPoints != null)
                {
                    foreach (var alarmPoint in AppSCADAProperties.SCADAAppConfiguration.CurrentAlarmPoints)
                    {
                        alarmPoints.Add(alarmPoint);
                    }
                    App.AlarmPage = new AlarmPage(alarmPoints);
                    App.AlarmPage.AlarmACK += AlarmPage_AlarmACK;
                }
                if(AppSCADAProperties.SCADAAppConfiguration.TrendViewSettings != null && AppSCADAProperties.SCADAAppConfiguration.TagLoggingSettings != null)
                {
                    App.TrendPage = new TrendPage();
                }

                OnLoadedConfiguration();
            }

        }

        public async Task RequestCurrentTagValue()
        {
            await _hubProxy.Invoke("GetCurrentTagsValue");
        }
        private void ReceiveACKAlarmPointSignalR(int alarmPointId)
        {
            alarmPoints.Remove(alarmPoints.FirstOrDefault(ap => ap.Id == alarmPointId));
        }

        private void ReceiveAlarmPointSignalR(AlarmPoint alarmPoint)
        {
            alarmPoints.Add(alarmPoint);
        }

        private void ReceiveCurrentTrendPointsSignalR(List<TrendPoint> trendPoints)
        {
            App.TrendPage.SetCurrentTrendPoints(trendPoints);
        }

        private void ReceiveTrendPointSignalR(TrendPoint trendPoint)
        {
            trendPoints.Add(trendPoint);
            App.TrendPage.AddNewTrendPoint(trendPoint);
        }
        public async Task WriteTagSignalR(int tagid, object value)
        {
            await _hubProxy.Invoke("WriteTag", tagid, value);
        }
        private void AlarmPage_AlarmACK(object sender, AlarmPointACKEventArgs e)
        {
            AckAlarmPointSignalR(e.AlarmPoint.Id);
        }
        private async void AckAlarmPointSignalR(int alarmId)
        {
            await _hubProxy.Invoke("AckAlarmPoint", alarmId);
            alarmPoints.Remove(alarmPoints.FirstOrDefault(ap => ap.Id == alarmId));
        }
        #endregion

        #region Event
        private event EventHandler _LoadedConfiguration;
        public event EventHandler LoadedConfiguration
        {
            add
            {
                _LoadedConfiguration += value;
            }
            remove
            {
                _LoadedConfiguration -= value;
            }
        }

        void OnLoadedConfiguration()
        {
            if (_LoadedConfiguration != null)
            {
                _LoadedConfiguration(this, new EventArgs());
            }
        }

        public delegate void TagUpdatedEventHandler(TagInfo tag);
        public event TagUpdatedEventHandler TagUpdated;
        #endregion
    }

}
