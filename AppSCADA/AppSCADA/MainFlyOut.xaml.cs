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
            if(item.TargetType == typeof(MainPage))
            {
                 MainPage page = App.mainPage;
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