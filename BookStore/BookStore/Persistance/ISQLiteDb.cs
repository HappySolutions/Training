using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Persistance
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();        
    }
}
