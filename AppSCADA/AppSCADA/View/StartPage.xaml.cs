using AppSCADA.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppSCADA
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            InitializeComponent();
            AppSCADAController.Instance.LoadedConfiguration += Instance_LoadedConfiguration;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            (sender as Button).IsEnabled = false;
            AppSCADAController.Instance.serverURL = txtSeverurl.Text;
            LoadingCircle.IsRunning = true;
            bool ConnectResult = await AppSCADAController.Instance.connectAsync();
            if (ConnectResult)
            {

            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Connect Fail", "Plese check URL or network", "OK");
            }
            LoadingCircle.IsRunning = false;
            (sender as Button).IsEnabled = true;
        }

        private void Instance_LoadedConfiguration(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                if (App.mainFlyOut == null)
                {
                    App.mainFlyOut = new MainFlyOut();
                }
                App.mainFlyOut.Detail = new NavigationPage(App.SCADAViewPageList.FirstOrDefault(p => p.Id == AppSCADAProperties.SCADAAppConfiguration.MainPageId));
                App.CurrentPageId = AppSCADAProperties.SCADAAppConfiguration.MainPageId;
                await Navigation.PushAsync(App.mainFlyOut);
            });

        }
    }
}