using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SweetsDokkana.Presistance
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}
