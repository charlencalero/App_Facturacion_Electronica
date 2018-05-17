using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AppMovilFE.Droid.Services;
using AppMovilFE.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(SaveAndLoad))]

namespace AppMovilFE.Droid.Services
{


        public class SaveAndLoad : ISaveAndLoad
        {
            public void SaveText(string filename, string text)
            {
                var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                var filePath = Path.Combine(documentsPath, filename);
                System.IO.File.WriteAllText(filePath, text);
            }
            public string LoadText(string filename)
            {
                var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                var filePath = Path.Combine(documentsPath, filename);
                return System.IO.File.ReadAllText(filePath);
            }
        
        }
}