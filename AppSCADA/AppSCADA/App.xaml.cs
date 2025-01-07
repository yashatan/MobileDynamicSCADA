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
        public static TagLoggingPage TagLoggingPage {  get; set; } 
        public static List<SCADAViewPage> SCADAViewPageList { get; set; }
        public static List<TableViewPage> TableViewPageList { get; set; }
        public static int CurrentPageId;
        public static MainFlyOut mainFlyOut;
        public App()
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new MainPage());
            //NavigationPage StartPage;
            SCADAViewPageList = new List<SCADAViewPage>();
            TableViewPageList = new List<TableViewPage>();
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
