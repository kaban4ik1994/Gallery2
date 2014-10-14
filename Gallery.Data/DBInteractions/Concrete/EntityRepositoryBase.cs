using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Gallery.Data.DBInteractions.Interface;

namespace Gallery.Data.DBInteractions.Concrete
{
    public class EntityRepositoryBase<T> where T : class
    {
        private GalleryContext _dataContext;
        private readonly IDbSet<T> _dbSet;

        protected EntityRepositoryBase(IDbFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;
            _dbSet = DataContext.Set<T>();
        }

        protected IDbFactory DatabaseFactory { get; private set; }
        protected GalleryContext DataContext { get { return _dataContext ?? (_dataContext = DatabaseFactory.Get()); } }

        public virtual void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            _dataContext.Entry(entity).State=EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void Delete(Func<T, Boolean> where)
        {
            IEnumerable<T> objects = _dbSet.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
            {
                _dbSet.Remove(obj);
            }
        }

        public virtual T GetById(long id)
        {
            return _dbSet.Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public virtual IEnumerable<T> GetMany(Func<T, bool> where)
        {
            return _dbSet.Where(where).ToList();
        }

        public T Get(Func<T, Boolean> where)
        {
            return _dbSet.Where(where).FirstOrDefault<T>();
        }
    }
}
