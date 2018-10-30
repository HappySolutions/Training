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
using MessagingCenterDemo.Droid.Persistance;
using MessagingCenterDemo.Persistance;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteDb))]

namespace MessagingCenterDemo.Droid.Persistance
{
    class SQLiteDb : ISQLiteDb
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