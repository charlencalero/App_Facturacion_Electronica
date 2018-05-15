using AppMovilFE.Droid.Services.EF;
using AppMovilFE.Services;



[assembly: global::Xamarin.Forms.Dependency(typeof(DatabaseService))]

namespace AppMovilFE.Droid.Services.EF
{
    public class DatabaseService: IDatabaseService
    {
        public string GetDatabasePath()
        {
            return Path.Combine(
                System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                AppSettings.DatabaseName);
        }
    }
}

