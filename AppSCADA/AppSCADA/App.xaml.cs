using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppSCADA
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new MainPage());
            //NavigationPage StartPage;
            MainPage = new StartPage();
           // MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
