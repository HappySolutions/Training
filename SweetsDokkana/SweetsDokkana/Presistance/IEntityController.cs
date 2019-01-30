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
    public interface IEntityController<T> where T : class, new()
    {
        void CreateTableRegAsync();

        Task<List<T>> GetAllAsync();

        Task<T> Get(int id);

        Task<RegEntity> GetReg(string email, string password);

        Task<RegEntity> CheckMail(string email);

        Task<RegEntity> getbyId(int id);

        Task<int> Insert(T entity);

        Task<int> Update(T entity);

        Task<int> Delete(T entity);

    }
}