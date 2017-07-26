using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Infrastructure
{
    public class RepositoryBase<T> : IRepository<T> where T : class
    {
        protected IDbSet<T> DbSet;
        protected BookmarkContext DbContext;

        public RepositoryBase(IDatabaseFactory factory)
        {
            DbContext = factory.Context;
            DbSet = DbContext.Set<T>();
        }

        public void Add(T entity) => DbSet.Add(entity);

        public int Count() => DbSet.Count();

        public int Count(Expression<Func<T, bool>> where) => DbSet.Count(where);

        public void Delete(T entity) => DbSet.Remove(entity);

        public void Delete(Expression<Func<T, bool>> where)
        {
            var entities = DbSet.Where(where).AsEnumerable();
            foreach(var e in entities) {
                DbSet.Remove(e);
            }
        }

        public T Get(Expression<Func<T, bool>> where) => DbSet.FirstOrDefault(where);

        public IEnumerable<T> GetAll() => DbSet.AsEnumerable();

        public T GetById(long id) => DbSet.Find(id);
        public T GetById(string id) => DbSet.Find(id);

        public IEnumerable<T> GetMany(Expression<Func<T, bool>> where) => DbSet.Where(where).AsEnumerable();

        public void Update(T entity)
        {
            DbSet.Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
        }
    }

    public interface IRepository<T> where T: class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> where);
        T GetById(long id);
        T GetById(string id);
        T Get(Expression<Func<T, bool>> where);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);

        int Count();
        int Count(Expression<Func<T, bool>> where);
    }
}
