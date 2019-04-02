using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListViewEventBubbles
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            var vm = new ViewModels.BanksViewModel();
            this.BindingContext = vm;
            //LVBanks.ItemsSource = vm.Banks;
        }
    }
}
