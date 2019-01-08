using System.IO;
using SQLite;
using SweetsDokkana.Droid.Presistance;
using SweetsDokkana.Presistance;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteDb))]
namespace SweetsDokkana.Droid.Presistance
{
    class SQLiteDb : ISQLiteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, "SQLiteDb.db3");

            return new SQLiteAsyncConnection(path);
        }
    }
}