﻿using AppSCADA.Utility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppSCADA
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainFlyOutFlyout : ContentPage
    {
        public ListView ListView;

        public MainFlyOutFlyout()
        {
            InitializeComponent();

            BindingContext = new MainFlyOutFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        private class MainFlyOutFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MainFlyOutFlyoutMenuItem> MenuItems { get; set; }

            public MainFlyOutFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<MainFlyOutFlyoutMenuItem>(new[]
                {
                    new MainFlyOutFlyoutMenuItem { Id = 0, Title = "SCADA View Page" , TargetType=typeof(SCADAViewPage)},
                    new MainFlyOutFlyoutMenuItem { Id = 1, Title = "Alarm Page", TargetType=typeof(AlarmPage)},
                    new MainFlyOutFlyoutMenuItem { Id = 2, Title = "Trend Page", TargetType=typeof(TrendPage)},
                    new MainFlyOutFlyoutMenuItem { Id = 3, Title = "Tag Logging Page", TargetType=typeof(TagLoggingPage)},
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                AppSCADAController.Instance.Disconnect();
            }
            catch
            {

            }
            App.SCADAViewPageList.Clear();
            App.TableViewPageList.Clear();
            await Navigation.PopToRootAsync();
        }
    }
}