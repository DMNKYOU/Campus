using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CampusCRM.DAL.Entities;

namespace CampusCRM.DAL.Interfaces
{
    public interface IRepositoryAsync<T> where T : class
    {
        Task<T> GetAsync(int id);
        Task<List<T>> GetAllAsync();
        IEnumerable<T> Find(Func<T, Boolean> predicate);
        Task CreateAsync(T item);
        Task UpdateAsync(T item);
        Task DeleteAsync(int id);
    }
}
