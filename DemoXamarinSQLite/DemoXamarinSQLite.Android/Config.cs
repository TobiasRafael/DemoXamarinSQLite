using SQLite.Net.Interop;
using Xamarin.Forms;

[assembly: Dependency(typeof(DemoXamarinSQLite.Droid.Config))]
namespace DemoXamarinSQLite.Droid
{
    public class Config : IConfig
    {
        private string _directoryDB;
        private ISQLitePlatform _platform;


        public string DirectoryDB
        {
            get
            {
                if (string.IsNullOrEmpty(_directoryDB))
                {
                    _directoryDB = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                }
                return _directoryDB;
            }
        }

        public ISQLitePlatform Platform
        {
            get
            {
                if (_platform == null)
                {
                    _platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
                }
                return _platform;
            }
        }

    }
}