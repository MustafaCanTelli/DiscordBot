using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.Service
{
   public interface ICoreService<T> where T:BaseEntity
    {
        void Add(T model);

        void Add(List<T> models);

        T GetbyId(T id);

        List<T> GetAll();

        void Remove(T id);

        List<T> GetDefault(Expression<Func<T, bool>> exp);

        bool Any(Expression<Func<T, bool>> exp);

        List<T> GetActive();
    }
}
