using BookStore.Droid.Persistance;
using BookStore.Persistance;
using SQLite;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteDb))]

namespace BookStore.Droid.Persistance
{
    public class SQLiteDb : ISQLiteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
            // Getting the path on the local device
            var dbPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            //combine the databasename with the path
            var path = Path.Combine(dbPath, "MySQLite.db3");

            //return the connection with the path
            return new SQLiteAsyncConnection(path);
        }
    }
}