using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNet.SignalR.Client;
using System.Collections.ObjectModel;
using Microsoft.AspNet.SignalR.Client.Hubs;
using System.Net;
using System.Threading.Tasks;

namespace AppSCADA.Utility
{
    public class AppSCADAController
    {
        HubConnection _signalRConnection;
        IHubProxy _hubProxy;
        string serverURL;
        public AppSCADAController()
        {
            
        }

        //private async Task connectAsync()
        //{
        //    //Create a connection for the SignalR server
        //    var url = serverURL;
        //    var _signalRConnection = new HubConnection(url);
        //    _signalRConnection.StateChanged += HubConnection_StateChanged;

        //    _hubProxy = _signalRConnection.CreateHubProxy("SCADAHub");
        //    _hubProxy.On<int, int>("UpdateTags", (tagid, value) => UpdateTagsSignalR(tagid, value));
        //    _hubProxy.On<SCADAAppConfiguration>("DownloadSCADAConfig", (config) => GetSCADAConfig(config));
        //    _hubProxy.On<AlarmPoint>("UpdateAlarmPoint", (alarmPoint) => ReceiveAlarmPointSignalR(alarmPoint));
        //    _hubProxy.On<int>("ACKAlarmPoint", (alarmPointId) => ReceiveACKAlarmPointSignalR(alarmPointId));
        //    _hubProxy.On<TrendPoint>("WriteTrendPoint", (trendPoint) => ReceiveTrendPointSignalR(trendPoint));
        //    _hubProxy.On<List<TrendPoint>>("WriteCurrentTrendPoints", (trendPoints) => ReceiveCurrentTrendPointsSignalR(trendPoints));

        //    //btnConnect.Enabled = false;

        //    try
        //    {
        //        //Connect to the server
        //        await _signalRConnection.Start();
        //        await _hubProxy.Invoke("SetUserName", "test");

        //    }
        //    catch (Exception ex)
        //    {
        //        // writeToLog($"Error:{ex.Message}");
        //        // btnConnect.Enabled = true;
        //    }
        //}

        private void HubConnection_StateChanged(StateChange obj)
        {
            if (obj.NewState == Microsoft.AspNet.SignalR.Client.ConnectionState.Connected)
                Console.WriteLine("Connected");
            else if (obj.NewState == Microsoft.AspNet.SignalR.Client.ConnectionState.Disconnected)
                Console.WriteLine("Disconnected");
        }
    }
}
