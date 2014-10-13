using System;
using System.Collections.Generic;

namespace Gallery.Data.DBInteractions
{
    public interface IEntityRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T delete);
        void Delete(Func<T, Boolean> predicate);
        T GetById(long id);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetMany(Func<T, bool> where);
    }
}
