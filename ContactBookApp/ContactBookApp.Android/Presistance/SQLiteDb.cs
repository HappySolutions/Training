using System.IO;
using ContactBookApp.Droid.Presistance;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteDb))]

namespace ContactBookApp.Droid.Presistance
{
    // This is the second step to implement the interface to get the connection 
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