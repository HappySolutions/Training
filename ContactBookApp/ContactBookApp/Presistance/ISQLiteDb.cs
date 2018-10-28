using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactBookApp
{
    //This is the first step of connecting to sqlite creating an interface that returns the new connection to the databse

    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}
