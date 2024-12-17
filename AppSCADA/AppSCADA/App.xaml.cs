using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppSCADA
{
    public partial class App : Application
    {
        public static MainPage mainPage {  get; private set; } 
        public App()
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new MainPage());
            //NavigationPage StartPage;
            mainPage = new MainPage();
            MainPage = new NavigationPage(new StartPage());
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
