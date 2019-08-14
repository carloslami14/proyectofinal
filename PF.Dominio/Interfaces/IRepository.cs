using System.Collections.Generic;

namespace PF.Dominio.Interfaces
{
    public interface IRepository<TEntity>
                where TEntity : class, new()
    {
        void Add(TEntity item);
        void Delete(TEntity item);
        void Modify(TEntity item);
        void Modify(List<TEntity> items);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<K> GetAll<K>() where K : TEntity, new();
    }
}