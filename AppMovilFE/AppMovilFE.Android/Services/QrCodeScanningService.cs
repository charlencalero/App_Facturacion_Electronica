using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing.Mobile;
using AppMovilFE.Services;

[assembly: Dependency(typeof(AppMovilFE.Android.Services.QrCodeScanningService))]

namespace AppMovilFE.Android.Services
{
    public class QrCodeScanningService : IQrScan
    {
        public async Task<string> ScanAsync()
        {
            
            var options = new MobileBarcodeScanningOptions();
            var scanner = new MobileBarcodeScanner();
            var scanResult = await scanner.Scan(options);
            return scanResult.Text;
        }
    }
}
