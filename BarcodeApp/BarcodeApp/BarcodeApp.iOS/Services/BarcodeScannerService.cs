using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarcodeApp.Services;
using Foundation;
using UIKit;
using Xamarin.Forms;
using ZXing.Mobile;

[assembly:Dependency(typeof(BarcodeApp.iOS.Services.BarcodeScannerService))]
namespace BarcodeApp.iOS.Services
{
    public class BarcodeScannerService : IBarcodeScannerService
    {
        public async Task<string> ScanAsync()
        {
            var scanner = new MobileBarcodeScanner();
            var scanResults = await scanner.Scan();
            //Fix by Ale
            return (scanResults != null) ? scanResults.Text : string.Empty;
        }
    }
}