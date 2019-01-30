using SQLite;
using SweetsDokkana.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SweetsDokkana.Presistance
{
    public class EntityController<T> : IEntityController<T> where T : class, new()
    {
        private SQLiteAsyncConnection _db;

        public EntityController(SQLiteAsyncConnection db)
        {
            this._db = db;
        }
        //Function To create table
        public async void CreateTableRegAsync()
        {
            await  _db.CreateTableAsync<RegEntity>();
        }
                
        //Function to get all the data in a list
        public async Task<List<T>> GetAllAsync()
        {
            return await _db.Table<T>().ToListAsync();
        }

        //Function to Get the data of an item using id
        public async Task<T> Get(int id)
        {
            return await _db.FindAsync<T>(id);
        }

        //Function to Get the data of an item using 2 variables
        public async Task<RegEntity> GetReg(string email, string password)
        {
            return await _db.Table<RegEntity>().FirstAsync(x => (x.Email == email && x.Password == password));
        }

        //overload for the previuos function using one variable
        public Task<RegEntity> CheckMail(string email)
        {
            return _db.Table<RegEntity>().FirstOrDefaultAsync(x => (x.Email == email));
        }

        //overload for the previuos function using one variable
        public Task<RegEntity> getbyId(int id)
        {
            return _db.Table<RegEntity>().FirstOrDefaultAsync(x => (x.ID == id));
        }

        //Function to Insert new Item
        public async Task<int> Insert(T entity)
        {
            return await _db.InsertAsync(entity);
        }

        //Function for updating an Item
        public async Task<int> Update(T entity)
        {
            return await _db.UpdateAsync(entity);
        }

        //Function for Deleting an Item
        public async Task<int> Delete(T entity)
        {
            return await _db.DeleteAsync(entity);
        }
    }
}
