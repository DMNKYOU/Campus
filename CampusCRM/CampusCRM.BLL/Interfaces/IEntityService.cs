using System.Collections.Generic;


namespace CampusCRM.BLL.Interfaces
{
    public interface IEntityService<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        void Add(TEntity entity);
        void Edit(TEntity entity);
        void Delete(int id);
        void Dispose();
    }
}