using SQLite.Net.Interop;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppMovilFE.Services
{
   public interface ISqlConfi
    {
        string DirectoryDB { get; }
        ISQLitePlatform Platform { get; }
    }
}
