using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AppMovilFE.Services;
using SQLite.Net.Interop;
using Xamarin.Forms;

[assembly: Dependency(typeof(AppMovilFE.Droid.Services.SQLConfi))]

namespace AppMovilFE.Droid.Services
{
    public class SQLConfi : ISqlConfi
    {

        private string directory;
        ISQLitePlatform platform;

        public string DirectoryDB
        {
            get
            {
                if (string.IsNullOrEmpty(directory))
                {
                    directory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                }

                return directory;
            }
        }

        public ISQLitePlatform Platform
        {
            get
            {
                if (platform == null)
                {
                    platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
                }

                return platform;
            }
        }
    }
}