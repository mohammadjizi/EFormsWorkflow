using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Workflow.Data.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        // Marks an entity as new
        void Add(T entity);
        // Marks an entity as modified
        void Update(T entity);
        // Marks an entity to be removed
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> where);
        // Get an entity by int id
        Task<T> GetById(int id);
        // Get an entity using delegate
        Task<T> Get(Expression<Func<T, bool>> where);
        // Gets all entities of type T
        Task<List<T>> GetAll();
        // Gets entities using delegate
        Task<List<T>> GetMany(Expression<Func<T, bool>> where);

        int Max(Expression<Func<T, int>> where);
    }
}
