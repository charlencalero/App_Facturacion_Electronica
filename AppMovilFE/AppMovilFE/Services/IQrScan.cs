using System;
using System.Threading.Tasks;

namespace AppMovilFE.Services
{
    public interface IQrScan
    {Task<string> ScanAsync();
    }


}
