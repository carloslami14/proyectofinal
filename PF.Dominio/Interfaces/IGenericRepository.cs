using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PF.Dominio.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int Id);
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
        void Save();
    }
}