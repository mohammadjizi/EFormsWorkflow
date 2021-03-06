﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Workflow.Data.Infrastructure
{
    public abstract class RepositoryBase<T> where T : class
    {
        #region Properties
        private WorkflowEntities dataContext;

        private IConfiguration _configuration;

        //private readonly IDbSet<T> dbSet;
        private readonly DbSet<T> dbSet;

        protected IDbFactory DbFactory
        {
            get;
            private set;
        }

        protected WorkflowEntities DbContext
        {
            get { return dataContext ?? (dataContext = DbFactory.Init(_configuration)); }
        }
        #endregion

        protected RepositoryBase(IDbFactory dbFactory, IConfiguration configuration)
        {
            DbFactory = dbFactory;
            _configuration = configuration;
            dbSet = DbContext.Set<T>();
        }

        #region Implementation
        public virtual void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            dbSet.Attach(entity);
            dataContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = dbSet.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                dbSet.Remove(obj);
        }

        public virtual Task<T> GetById(int id)
        {
            return dbSet.FindAsync(id);
        }

        public virtual Task<List<T>> GetAll()
        {
            return dbSet.ToListAsync();
        }

        public virtual Task<List<T>> GetMany(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).ToListAsync();
        }

        public Task<T> Get(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).FirstOrDefaultAsync<T>();
        }

        public int Max(Expression<Func<T, int>> where)
        {
          return  dbSet.Max(where);
        }
        #endregion

    }
}
