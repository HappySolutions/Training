using System.IO;
using ContactBookApp.Droid.Presistance;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteDb))]

namespace ContactBookApp.Droid.Presistance
{
    public class SQLiteDb : ISQLiteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {

            var dbPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(dbPath, "MySQLite.db3");

            return new SQLiteAsyncConnection(path);
        }
    }
}