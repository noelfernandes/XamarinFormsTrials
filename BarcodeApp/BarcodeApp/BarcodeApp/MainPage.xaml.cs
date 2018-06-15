using BarcodeApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BarcodeApp
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        private async void BttnScan_Clicked(object sender, EventArgs e)
        {
            var scanner = DependencyService.Get<IBarcodeScannerService>();
            var result = await scanner.ScanAsync();
            if (result != null)
                TxtScanResults.Text = result;
        }
    }
}
