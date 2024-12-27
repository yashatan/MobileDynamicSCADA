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
        }

         private async void Button_Clicked(object sender, EventArgs e)
        {
            (sender as Button).IsEnabled = false;
            AppSCADAController.Instance.serverURL = txtSeverurl.Text;
            AppSCADAController.Instance.LoadedConfiguration += Instance_LoadedConfiguration;
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
            Device.BeginInvokeOnMainThread(async () => {
                MainFlyOut mainFlyOut = new MainFlyOut();
                mainFlyOut.Detail = new NavigationPage(App.PageList.FirstOrDefault(p => p.Id == AppSCADAProperties.SCADAAppConfiguration.MainPageId));
                App.CurrentPageId = AppSCADAProperties.SCADAAppConfiguration.MainPageId;
                await Navigation.PushAsync(mainFlyOut);
            });

        }
    }
}