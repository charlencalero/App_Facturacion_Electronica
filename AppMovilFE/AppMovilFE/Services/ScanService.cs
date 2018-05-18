using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace AppMovilFE.Services
{
    public class ScanService
    {
        public async Task<string> ScannerQr()
        {
            try
            {
                var scanner = DependencyService.Get<IQrScan>();
                var result = await scanner.ScanAsync();
                return result.ToString();
            }
            catch (Exception ex)
            {
                //return ex.Message;
                return "";

            }
        }
    }
}
