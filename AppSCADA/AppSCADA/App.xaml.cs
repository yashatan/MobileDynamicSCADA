using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.Generic;

namespace AppSCADA
{
    public partial class App : Application
    {
        public static SCADAViewPage mainPage {  get; private set; } 
        public static AlarmPage AlarmPage {  get; set; } 
        public static TrendPage TrendPage {  get; set; } 
        public static List<SCADAViewPage> SCADAViewPageList { get; set; }
        public static int CurrentPageId;
        public static MainFlyOut mainFlyOut;
        public App()
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new MainPage());
            //NavigationPage StartPage;
            SCADAViewPageList = new List<SCADAViewPage>();
            MainPage = new NavigationPage(new StartPage());
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
