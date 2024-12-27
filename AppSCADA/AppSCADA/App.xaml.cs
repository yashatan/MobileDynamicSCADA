using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.Generic;

namespace AppSCADA
{
    public partial class App : Application
    {
        public static MainPage mainPage {  get; private set; } 
        public static AlarmPage AlarmPage {  get; set; } 
        public static List<MainPage> PageList { get; set; }
        public static int CurrentPageId;
        public App()
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new MainPage());
            //NavigationPage StartPage;
            PageList = new List<MainPage>();
            //alarmPage = new AlarmPage();
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
