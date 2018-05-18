using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing.Mobile;
using AppMovilFE.Services;

[assembly: Dependency(typeof(AppMovilFE.iOS.Services.QrCodeScanningService))]

namespace AppMovilFE.iOS.Services
{
    public class QrCodeScanningService: IQrScan
    {
        public QrCodeScanningService()
        {
        }

        public async Task<string> ScanAsync()
        {
            var scanner = new MobileBarcodeScanner();
            var scanResult = await scanner.Scan();
            return scanResult.Text;
        }
    }
}
