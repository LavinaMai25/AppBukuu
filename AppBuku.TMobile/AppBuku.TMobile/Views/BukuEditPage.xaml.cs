using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppBuku.TMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BukuEditPage : ContentPage
    {
        public BukuEditPage()
        {
            InitializeComponent();
            BindingContext = new ViewModels.BukuEditViewModel();
        }
    }
}