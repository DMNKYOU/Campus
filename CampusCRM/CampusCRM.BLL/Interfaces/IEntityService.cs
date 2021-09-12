using System.Collections.Generic;
using System.Threading.Tasks;
using CampusCRM.DAL.Entities;


namespace CampusCRM.BLL.Interfaces
{
    public interface IEntityService<TEntity>
    {
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task AddAsync(TEntity entity);//
        Task EditAsync(TEntity entity); //
        Task DeleteAsync(int id);
        void Dispose(); ///////////////////////////
    }
}