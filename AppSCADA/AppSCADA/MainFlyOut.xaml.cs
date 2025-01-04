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
    public partial class MainFlyOut : FlyoutPage
    {
        public MainFlyOut()
        {
            InitializeComponent();
            FlyoutPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MainFlyOutFlyoutMenuItem;
            if (item == null)
                return;
            if(item.TargetType == typeof(SCADAViewPage))
            {
                SCADAViewPage page = App.SCADAViewPageList.FirstOrDefault(p => p.Id == App.CurrentPageId);
                page.Title = item.Title;
                Detail = new NavigationPage(page);
                IsPresented = false;
                FlyoutPage.ListView.SelectedItem = null;
            }
            else if (item.TargetType == typeof(AlarmPage))
            {
                AlarmPage page = App.AlarmPage;
                page.Title = item.Title;
                Detail = new NavigationPage(page);
                IsPresented = false;
                FlyoutPage.ListView.SelectedItem = null;
            }
            else if (item.TargetType == typeof(TrendPage))
            {
                TrendPage page = App.TrendPage;
                page.Title = item.Title;
                Detail = new NavigationPage(page);
                IsPresented = false;
                FlyoutPage.ListView.SelectedItem = null;
            }
            else if (item.TargetType == typeof(TagLoggingPage))
            {
                TagLoggingPage page = App.TagLoggingPage;
                page.Title = item.Title;
                Detail = new NavigationPage(page);
                IsPresented = false;
                FlyoutPage.ListView.SelectedItem = null;
            }
            else
            {
                var page = (Page)Activator.CreateInstance(item.TargetType);
                page.Title = item.Title;
                Detail = new NavigationPage(page);
                IsPresented = false;
                FlyoutPage.ListView.SelectedItem = null;
            }
        }
    }
}