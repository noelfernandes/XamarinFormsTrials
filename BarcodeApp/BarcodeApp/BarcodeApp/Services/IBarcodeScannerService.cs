using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeApp.Services
{
    public interface IBarcodeScannerService
    {
        Task<string> ScanAsync();
    }
}
