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
#pragma warning disable CS0693 // Type parameter has the same name as the type parameter from outer type
        Task<CreateTableResult> CreateTableAsync<T>(CreateFlags createFlags = CreateFlags.None) where T : new();
#pragma warning restore CS0693 // Type parameter has the same name as the type parameter from outer type

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