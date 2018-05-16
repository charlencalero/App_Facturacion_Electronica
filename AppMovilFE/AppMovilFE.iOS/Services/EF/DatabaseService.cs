using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AppMovilFE.iOS.Services.EF;
using AppMovilFE.Services;
using Foundation;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(DatabaseService))]

namespace AppMovilFE.iOS.Services.EF
{
    public class DatabaseService : IDatabaseService
    {
        public string GetDatabasePath()
        {

          
            return Path.Combine(Environment.GetFolderPath(
                Environment.SpecialFolder.Personal),
                "..",
                "Library",
                AppSettings.DatabaseName);
        }
    }
}