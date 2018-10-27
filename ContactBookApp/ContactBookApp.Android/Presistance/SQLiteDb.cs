using System.IO;
using SQLite;

namespace ContactBookApp.Droid.Presistance
{
    public class SQLiteDb : ISQLiteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var dbName = "sqliteDb.db";
            var dbPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(dbName, dbPath);

            return new SQLiteAsyncConnection(path);
        }
    }
}