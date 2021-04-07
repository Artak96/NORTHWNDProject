using NorthWndCore.Abstractions.Repositories;
using NorthWndCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NorthWndDAL
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly NORTHWNDContext context;
        public RepositoryBase(NORTHWNDContext  context)
        {
            this.context = context;
        }

        public  void Add(T entity)
        {
            context.Set<T>().Add(entity);
        }

        public  void AddRange(IEnumerable<T> entity)
        {
            context.Set<T>().AddRange(entity);
        }

        public  T Get(int id)
        {
            var result = context.Set<T>().Find(id);
            return result;
        }

        public  IEnumerable<T> GetAll()
        {
            var result = context.Set<T>().ToList();
            return result;
        }

        public  T GetSingle(Func<T, bool> predicate)
        {
            return context.Set<T>().FirstOrDefault(predicate);
        }

        public  void Remove(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        public  void Update(T entity)
        {
            context.Set<T>().Update(entity);
        }
    }
}
