﻿using SQLite;
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

       /* public int AddItem(RegEntity reg)
        {
            var AddedItem =  _connection.InsertAsync(reg);
            return AddedItem;
        }*/


    }
    }

