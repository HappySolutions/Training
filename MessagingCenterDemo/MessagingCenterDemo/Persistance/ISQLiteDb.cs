using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MessagingCenterDemo.Persistance
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}
