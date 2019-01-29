using SQLite;
using SweetsDokkana.Presistance;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SweetsDokkana.Models
{
    public class SqlHelper
    {
        static object locker = new object();
        private SQLiteAsyncConnection _connection;

        private static readonly AsyncLock AsyncLock = new AsyncLock();


        public SqlHelper()
        {
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();

            _connection.CreateTableAsync<RegEntity>();
        }

        public Task<RegEntity> GetItem(string email, string password)
        {
            lock (locker)
            {
                return _connection.Table<RegEntity>().FirstAsync(x => (x.Email == email && x.Password == password ));
            }
        }

        public Task<RegEntity> CheckMail(string email)
        {
            lock (locker)
            {
                return _connection.Table<RegEntity>().FirstOrDefaultAsync(x => (x.Email == email));
            }
        }

        public async Task<int> InsertAsync<T>(T entity)
        {
            try
            {
                using (await AsyncLock.LockAsync())
                {
                    if (entity != null) await _connection.InsertAsync(entity);
                   
                    return 1;
                }
            }
            catch (SQLiteException sqliteException)
            {
                {
                    return await InsertAsync(entity);
                }
                throw;
            }

        }


    }
    }

