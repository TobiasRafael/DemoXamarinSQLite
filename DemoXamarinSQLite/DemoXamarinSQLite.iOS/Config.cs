using System;
using SQLite.Net.Interop;
using Xamarin.Forms;

[assembly: Dependency(typeof(DemoXamarinSQLite.iOS.Config))]
namespace DemoXamarinSQLite.iOS
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
                    var directory = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    _directoryDB = System.IO.Path.Combine(directory, "..", "Library");
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
                    _platform = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
                }
                return _platform;
            }
        }




    }
}