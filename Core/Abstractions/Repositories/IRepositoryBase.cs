using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWndCore.Abstractions.Repositories
{
    public interface IRepositoryBase<T> where T : class
    {
        void Add(T entity);
        void AddRange(IEnumerable<T> entity);
        void Remove(T entity);
        void Update(T entity);
        IEnumerable<T> GetAll();
        T Get(int id);
        T GetSingle(Func<T, bool> predicate);

    }
}
