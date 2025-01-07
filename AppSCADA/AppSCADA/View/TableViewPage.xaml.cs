using AppSCADA.Utility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppSCADA
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TableViewPage : ContentPage
    {

        private ObservableCollection<TagInfo> tagInfos;
        private TablePage TablePageSetting;
        public new int Id { get; set; }
        public string Name { get; set; }
        public int PageType { get; set; }
        public TableViewPage()
        {
            InitializeComponent();

        }
        public TableViewPage(TablePage tablePage)
        {  
            InitializeComponent();
            this.TablePageSetting = tablePage;
            this.Id = tablePage.Id;
            this.Name = tablePage.Name;
            this.PageType = tablePage.PageType;
            MappingTag();
            tagInfos = new ObservableCollection<TagInfo>();
            foreach (TagInfo tagInfo in TablePageSetting.Tags)
            {
                tagInfos.Add(tagInfo);
            }
            lvTags.ItemsSource = tagInfos;
            BindingContext = this;
            AppSCADAController.Instance.TagUpdated += UpdateTagsSignalR;
        }

        private void MappingTag()
        {
            for (int i = 0; i < TablePageSetting.Tags.Count; i++)
            {
                var foundtag = AppSCADAProperties.SCADAAppConfiguration.TagInfos.FirstOrDefault(p => p.Id == TablePageSetting.Tags[i].Id);
                if (foundtag != null)
                {
                    TablePageSetting.Tags[i] = foundtag;
                }
                else
                {
                    TablePageSetting.Tags.RemoveAt(i);
                }
            }
        }

        private void UpdateTagsSignalR(TagInfo tag)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                //if (tagInfos.Any(t => t.Id == tag.Id))
                //{
                //    tagInfos.FirstOrDefault(t => t.Id == tag.Id).Value = tag.Value;
                //}
            });
        }

        private async void Entry_Unfocused(object sender, FocusEventArgs e)
        {
            var entry = sender as Entry;
            var chosenTag = entry.BindingContext as TagInfo;

            if (chosenTag != null)
            {
                var TagValue = (sender as Entry).Text;
                if (chosenTag.Value != TagValue)
                {
                    long datatowritelong;
                    double datatowritedouble;
                    if (long.TryParse(TagValue, out datatowritelong))
                    {
                        await AppSCADAController.Instance.WriteTagSignalR(chosenTag.Id, datatowritelong);
                    }
                    else if (double.TryParse(TagValue, out datatowritedouble))
                    {
                        await AppSCADAController.Instance.WriteTagSignalR(chosenTag.Id, datatowritedouble);
                    }
                }


            }
        }
    }


}