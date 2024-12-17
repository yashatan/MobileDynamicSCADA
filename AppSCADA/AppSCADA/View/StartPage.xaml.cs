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
            App.mainPage.url = txtSeverurl.Text;
            await App.mainPage.connectAsync();
            LoadingCircle.IsRunning = true;
            MainFlyOut mainFlyOut = new MainFlyOut();
            await Navigation.PushAsync(mainFlyOut);
        }
    }
}