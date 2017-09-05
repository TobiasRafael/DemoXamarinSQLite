using SQLite.Net.Interop;

namespace DemoXamarinSQLite
{
    public interface IConfig
    {

        string DirectoryDB { get; }
        ISQLitePlatform Platform { get; }
    }
}
