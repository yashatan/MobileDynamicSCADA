using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppSCADA.ViewModel;
using AppSCADA.Model;

namespace AppSCADA
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FacePlate : ContentPage
    {
        public FacePlate()
        {
            InitializeComponent();
        }       
        public FacePlate(Model.Device device, Motor motor)
        {
            InitializeComponent();
            this.BindingContext = new FacePlateViewModel(device, motor);
        }


    }
}